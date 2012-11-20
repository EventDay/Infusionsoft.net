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
using System.Linq.Expressions;
using System.Reflection;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    internal class TableFieldSetter<T> : FieldSetter<T> where T : ITable
    {
        private readonly Access _desiredAccess;

        public TableFieldSetter(Access desiredAccess)
        {
            _desiredAccess = desiredAccess;
        }

        public override IFieldSetter<T> Set<TV>(Expression<Func<T, TV>> expression, TV value)
        {
            PropertyInfo property = Express.PropertyWithLambda(expression);

            if (HasAccess(property))
            {
                base.Set(expression, value);
            }

            return this;
        }

        private bool HasAccess(PropertyInfo property)
        {
            object[] attributes = property.GetCustomAttributes(typeof (AccessAttribute), false);

            if (attributes.Length != 1)
            {
                return false;
            }

            if (!((AccessAttribute) attributes[0]).Access.HasFlag(_desiredAccess))
            {
                return false;
            }

            return true;
        }
    }
}