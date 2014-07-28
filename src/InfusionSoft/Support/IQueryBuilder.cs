#region License

// Copyright (c) 2014, EventDay
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
using InfusionSoft.Tables;

namespace InfusionSoft
{
    public interface IQueryBuilder<T> where T : ITable
    {
        IQueryBuilder<T> Add<TV>(Expression<Func<T, TV>> expression, TV value);
        IQueryBuilder<T> AddCustomField<TV>(string field, TV value);

        IQueryBuilder<T> Add<TV>(Expression<Func<T, TV>> expression, TV value, ValuePosition valuePosition);
        IQueryBuilder<T> AddCustomField<TV>(string field, TV value, ValuePosition valuePosition);

        IQueryBuilder<T> AddCustomQuery<TV>(Expression<Func<T, TV>> expression, object value,
            ValuePosition valuePosition);

        IQueryBuilder<T> AddCustomQuery<TV>(Expression<Func<T, TV>> expression, object value);

        void Empty();
    }
}