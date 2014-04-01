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
using System.Linq.Expressions;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    internal class QueryBuilder<T> : IQueryBuilder<T> where T : ITable
    {
        private Dictionary<string, object> _dictionary;

        public QueryBuilder()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Dictionary
        {
            get { return _dictionary; }
        }

        public IQueryBuilder<T> Add<TV>(Expression<Func<T, TV>> expression, TV value)
        {
            return Add(expression, value, ValuePosition.Default);
        }

        public IQueryBuilder<T> Add<TV>(Expression<Func<T, TV>> expression, TV value, ValuePosition valuePosition)
        {
            string name = Express.PropertyWithLambda(expression).Name;
            name = this.GetColumnName(name);
            _dictionary.Add(name, BuildPositionalValue(valuePosition, value));

            return this;
        }

        public IQueryBuilder<T> AddCustomField<TV>(string field, TV value)
        {
            return AddCustomField(field, value, ValuePosition.Default);
        }

        public IQueryBuilder<T> AddCustomField<TV>(string field, TV value, ValuePosition valuePosition)
        {
            _dictionary.Add(CustomField.NormalizeName(field), BuildPositionalValue(valuePosition, value));
            return this;
        }

        public void Empty()
        {
            _dictionary = new Dictionary<string, object>();
        }

        private string BuildPositionalValue<TValueType>(ValuePosition position, TValueType value)
        {
            IValuePosition<TValueType> valuePosition;

            switch (position)
            {
                case ValuePosition.StartsWith:
                    valuePosition = new StartsWithValue<TValueType>();
                    break;
                case ValuePosition.Contains:
                    valuePosition = new ContainsValue<TValueType>();
                    break;
                case ValuePosition.EndsWith:
                    valuePosition = new EndsWithValue<TValueType>();
                    break;
                default:
                    valuePosition = new DefaultValue<TValueType>();
                    break;
            }

            return valuePosition.BuildValue(value);
        }
    }
}