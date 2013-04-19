#region License

// Copyright (c) 2012, EventDay
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CookComputing.XmlRpc;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    internal class Projection<T> : IProjection<T> where T : new()
    {
        private readonly HashSet<string> _dynamicProperties;
        private readonly HashSet<PropertyInfo> _properties;
        private readonly HashSet<string> _ignores;

        public Projection()
        {
            _ignores = new HashSet<string>();
            _properties = new HashSet<PropertyInfo>();
            _dynamicProperties = new HashSet<string>();
        }

        public IProjection<T> Include<TV>(Expression<Func<T, TV>> expression)
        {
            _properties.Add(Express.PropertyWithLambda(expression));
            return this;
        }

        public IProjection<T> Ignore<TV>(Expression<Func<T, TV>> expression)
        {
            _ignores.Add(GetXmlRpcMemberName(Express.PropertyWithLambda(expression)));
            return this;
        }

        public IProjection<T> IncludeCustomField(string property)
        {
            _dynamicProperties.Add(CustomField.NormalizeName(property));
            return this;
        }

        public IProjection<T> IncludeNamed(string property)
        {
            _dynamicProperties.Add(property);
            return this;
        }

        public IProjection<T> IncludeAll()
        {
            _properties.Clear();
            var infos = typeof (T).GetProperties()
                                  .Where(p => !p.Name.Equals("CustomFields") && !p.Name.EndsWith("Comparer"))
                                  .Where(p =>
                                      {
                                          var attributes = p.GetCustomAttributes(typeof (AccessAttribute), false);
                                          if (!attributes.Any())
                                              return false;

                                          var attribute = attributes.Cast<AccessAttribute>().First();

                                          return attribute.Access.HasFlag(Access.Read);
                                      });

            _properties.UnionWith(infos);
            return this;
        }

        public string[] Build()
        {
            if (_properties.Count == 0)
                IncludeAll();

            var set = new HashSet<string>(_properties.Select(GetXmlRpcMemberName));
            set.UnionWith(_dynamicProperties);
            return set.Except(_ignores).ToArray();
        }

        private string GetXmlRpcMemberName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes(false).OfType<XmlRpcMemberAttribute>().SingleOrDefault();
            if (attribute == null)
                return property.Name;
            return attribute.Member;
        }
    }
}