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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    internal class Projection<T> : IProjection<T>, ITableFieldBuilder<T> where T : new()
    {
        private readonly List<string> _dynamicProperties;
        private readonly List<PropertyInfo> _properties;

        public Projection()
        {
            _properties = new List<PropertyInfo>();
            _dynamicProperties = new List<string>();
        }

        public IProjection<T> Include<TV>(Expression<Func<T, TV>> expression)
        {
            _properties.Add(Express.PropertyWithLambda(expression));
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
            IEnumerable<PropertyInfo> infos =
                typeof (T).GetProperties().Where(p => !p.Name.Equals("CustomFields") && !p.Name.EndsWith("Comparer"));
            _properties.AddRange(infos);
            return this;
        }

        public string[] Build()
        {
            List<string> list = _properties.Select(p => p.Name).ToList();

            list.AddRange(_dynamicProperties);

            return list.ToArray();
        }

        public T Populate(IDictionary<string, string> values)
        {
            var foo = new T();
            var dynamicProps = new Dictionary<string, string>(_dynamicProperties.ToDictionary(k => k, v => string.Empty));

            foreach (var pair in values)
            {
                KeyValuePair<string, string> current = pair;

                PropertyInfo property =
                    _properties.FirstOrDefault(p => p.Name.Equals(current.Key, StringComparison.OrdinalIgnoreCase));

                if (property == null && !TryToForceProperty(current, out property))
                {
                    AddToDynamicProperties(current, dynamicProps);
                    continue;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                object realValue = converter.ConvertFrom(MassageStringValue(property, current.Value));
                property.SetValue(foo, realValue, null);
            }

            var table = foo as ITable;
            if (table != null)
            {
//                (table).CustomFields = dynamicProps;
            }
            return foo;
        }

        private bool TryToForceProperty(KeyValuePair<string, string> current, out PropertyInfo property)
        {
            string key = current.Key;

            int index = current.Key.IndexOf(".", StringComparison.Ordinal);
            if (index > -1)
                key = key.Remove(index, 1);

            property = _properties.FirstOrDefault(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase));
            return property != null;
        }

        private void AddToDynamicProperties(KeyValuePair<string, string> current,
                                            Dictionary<string, string> dynamicProps)
        {
            //TODO: Add dynamic objects instead of using underscores.
            string key = current.Key.Replace(".", "_");

            if (dynamicProps.ContainsKey(key))
            {
                dynamicProps[key] = current.Value;
            }
            else
            {
                dynamicProps.Add(key, current.Value);
            }
        }

        private static string MassageStringValue(PropertyInfo property, string value)
        {
            if (property.PropertyType == typeof (DateTime))
            {
                value = Regex.Replace(value, @"(\d{4})(\d{2})(\d{2})(?=[:\d\w]+)", "$1-$2-$2",
                                      RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }
            return value;
        }
    }
}