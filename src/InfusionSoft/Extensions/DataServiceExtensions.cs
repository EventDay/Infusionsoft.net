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
using CookComputing.XmlRpc;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    public static class DataServiceExtensions
    {
        public static IEnumerable<T> Query<T>(this IDataService service) where T : ITable, new()
        {
            return Query<T>(service, q => q.Empty(), p => p.IncludeAll());
        }

        public static IEnumerable<T> Query<T>(this IDataService service, string orderBy) where T : ITable, new()
        {
            return Query<T>(service, q => q.Empty(), p => p.IncludeAll(), orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, string orderBy, bool asc) where T : ITable, new()
        {
            return Query<T>(service, q => q.Empty(), p => p.IncludeAll(), orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder)
            where T : ITable, new()
        {
            return Query(service, queryBuilder, p => p.IncludeAll());
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder, string orderBy)
            where T : ITable, new()
        {
            return Query(service, queryBuilder, p => p.IncludeAll(), orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder, string orderBy, bool asc)
            where T : ITable, new()
        {
            return Query(service, queryBuilder, p => p.IncludeAll(), orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IProjection<T>> projection)
            where T : ITable, new()
        {
            return Query(service, q => q.Empty(), projection);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IProjection<T>> projection, string orderBy)
            where T : ITable, new()
        {
            return Query(service, q => q.Empty(), projection, orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IProjection<T>> projection, string orderBy, bool asc)
            where T : ITable, new()
        {
            return Query(service, q => q.Empty(), projection, orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder,
                                              Action<IProjection<T>> projection)
            where T : ITable, new()
        {
// ReSharper disable RedundantTypeArgumentsOfMethod
            return GetAllPages<T, Action<IQueryBuilder<T>>, Action<IProjection<T>>, string, bool>(service.Query, queryBuilder,
                                                                                    projection, String.Empty, false);
// ReSharper restore RedundantTypeArgumentsOfMethod
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder,
                                              Action<IProjection<T>> projection, string orderBy)
            where T : ITable, new()
        {
// ReSharper disable RedundantTypeArgumentsOfMethod
            return GetAllPages<T, Action<IQueryBuilder<T>>, Action<IProjection<T>>, string, bool>(service.Query, queryBuilder,
                                                                                    projection, orderBy, false);
// ReSharper restore RedundantTypeArgumentsOfMethod
        }

        public static IEnumerable<T> Query<T>(this IDataService service, Action<IQueryBuilder<T>> queryBuilder,
                                              Action<IProjection<T>> projection, string orderBy, bool asc)
            where T : ITable, new()
        {
// ReSharper disable RedundantTypeArgumentsOfMethod
            return GetAllPages<T, Action<IQueryBuilder<T>>, Action<IProjection<T>>, string, bool>(service.Query, queryBuilder,
                                                                                    projection, orderBy, asc);
// ReSharper restore RedundantTypeArgumentsOfMethod
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page) where T : ITable, new()
        {
            return Query<T>(service, page, builder => builder.Empty(), projection => projection.IncludeAll());
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page, string orderBy) where T : ITable, new()
        {
            return Query<T>(service, page, builder => builder.Empty(), projection => projection.IncludeAll(), orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page, string orderBy, bool asc) where T : ITable, new()
        {
            return Query<T>(service, page, builder => builder.Empty(), projection => projection.IncludeAll(), orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IQueryBuilder<T>> queryBuilder) where T : ITable, new()
        {
            return Query(service, page, queryBuilder, p => p.IncludeAll());
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IQueryBuilder<T>> queryBuilder, string orderBy) where T : ITable, new()
        {
            return Query(service, page, queryBuilder, p => p.IncludeAll(), orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IQueryBuilder<T>> queryBuilder, string orderBy, bool asc) where T : ITable, new()
        {
            return Query(service, page, queryBuilder, p => p.IncludeAll(), orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IProjection<T>> projection) where T : ITable, new()
        {
            return Query(service, page, builder => builder.Empty(), projection);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                             Action<IProjection<T>> projection, string orderBy) where T : ITable, new()
        {
            return Query(service, page, builder => builder.Empty(), projection, orderBy);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                             Action<IProjection<T>> projection, string orderBy, bool asc) where T : ITable, new()
        {
            return Query(service, page, builder => builder.Empty(), projection, orderBy, asc);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IQueryBuilder<T>> queryBuilder,
                                              Action<IProjection<T>> fieldSelection) where T : ITable, new()
        {
            return Query(service, page, queryBuilder, fieldSelection, String.Empty, false);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                             Action<IQueryBuilder<T>> queryBuilder,
                                             Action<IProjection<T>> fieldSelection, string orderBy) where T : ITable, new()
        {
            return Query(service, page, queryBuilder, fieldSelection, orderBy, false);
        }

        public static IEnumerable<T> Query<T>(this IDataService service, DataPage page,
                                              Action<IQueryBuilder<T>> queryBuilder,
                                              Action<IProjection<T>> fieldSelection, string orderBy, bool asc) where T : ITable, new()
        {
            var query = new QueryBuilder<T>();
            queryBuilder(query);

            var projection = new Projection<T>();
            fieldSelection(projection);

            XmlRpcStruct data = query.Dictionary.AsXmlRpcStruct();
            string[] selectedFields = projection.Build();

            var configuration = service.Configuration;
            var methodListenerProvider = service.MethodListenerProvider;
            var wrapper = new CustomDataServiceWrapper(configuration, methodListenerProvider);

            if (String.IsNullOrEmpty(orderBy))
            {
                return wrapper.Invoke<IEnumerable<object>, T[]>(d => d.Query(configuration.GetApiKey(),
                                                                             typeof(T).Name, page.Size,
                                                                             page.Number, data, selectedFields));
            }
            else
            {
                return wrapper.Invoke<IEnumerable<object>, T[]>(d => d.Query(configuration.GetApiKey(),
                                                                             typeof(T).Name, page.Size,
                                                                             page.Number, data, selectedFields, orderBy, asc));
            }
        }

        public static IEnumerable<T> FindByField<T>(this IDataService service, Action<IFieldQuery<T>> query)
            where T : ITable, new()
        {
            return FindByField(service, query, p => p.IncludeAll());
        }

        public static IEnumerable<T> FindByField<T>(this IDataService service, Action<IFieldQuery<T>> query,
                                                    Action<IProjection<T>> projection)
            where T : ITable, new()
        {
// ReSharper disable RedundantTypeArgumentsOfMethod
            return GetAllPages<T, Action<IFieldQuery<T>>, Action<IProjection<T>>>(service.FindByField, query, projection);
// ReSharper restore RedundantTypeArgumentsOfMethod
        }

        public static IEnumerable<T> FindByField<T>(this IDataService service, DataPage page,
                                                    Action<IFieldQuery<T>> query) where T : ITable, new()
        {
            return FindByField(service, page, query, p => p.IncludeAll());
        }

        public static IEnumerable<T> FindByField<T>(this IDataService service, DataPage page,
                                                    Action<IFieldQuery<T>> query,
                                                    Action<IProjection<T>> fieldSelection)
            where T : ITable, new()
        {
            var fieldQuery = new FieldQuery<T>();
            query(fieldQuery);

            var projection = new Projection<T>();
            fieldSelection(projection);

            var wrapper = new CustomDataServiceWrapper(service.Configuration, service.MethodListenerProvider);

            return wrapper.Invoke<IEnumerable<object>, T[]>(d => d.FindByField(service.Configuration.GetApiKey(),
                                                                               typeof (T).Name, page.Size,
                                                                               page.Number,
                                                                               fieldQuery.Name,
                                                                               fieldQuery.Value,
                                                                               projection.Build()));
        }

        public static int AddCustomField(this IDataService service, CustomFieldType fieldType, string displayName,
                                         int groupId)
        {
            return service.AddCustomField(fieldType.Name, displayName, fieldType.DataType, groupId);
        }

        public static int Add<T>(this IDataService service, Action<IFieldSetter<T>> setter) where T : ITable
        {
            var fieldSetter = new TableFieldSetter<T>(Access.Add);
            setter(fieldSetter);

            return service.Add(typeof (T).Name, fieldSetter.XmlStruct);
        }

        public static T Load<T>(this IDataService service, int id) where T : class, ITable, new()
        {
            return Load<T>(service, id, p => p.IncludeAll());
        }

        public static T Load<T>(this IDataService service, int id, Action<IProjection<T>> projection)
            where T : class, ITable, new()
        {
            var fieldSelection = new Projection<T>();
            projection(fieldSelection);

            var wrapper = new CustomDataServiceWrapper(service.Configuration, service.MethodListenerProvider);
            return
                wrapper.Invoke<object, T>(d => d.Load(service.Configuration.GetApiKey(), typeof (T).Name, id, fieldSelection.Build()));
        }

        public static int Update<T>(this IDataService service, int id, Action<IFieldSetter<T>> setter) where T : ITable
        {
            var fieldSetter = new TableFieldSetter<T>(Access.Edit);
            setter(fieldSetter);

            return service.Update(typeof (T).Name, id, fieldSetter.XmlStruct);
        }

        public static bool Delete<T>(this IDataService service, int id) where T : ITable, new()
        {
            return service.Delete(typeof (T).Name, id);
        }

        public static bool UpdateCustomField(this IDataService service, int customFieldId,
                                             Action<IBasicFieldSetter> setter)
        {
            var fieldSetter = new BasicFieldSetter();
            setter(fieldSetter);

            return service.UpdateCustomField(customFieldId, fieldSetter.Values.AsXmlRpcStruct());
        }

        public static IEnumerable<T> GetAllPages<T, T1, T2>(Func<DataPage, T1, T2, IEnumerable<T>> func, T1 arg1,
                                                            T2 arg2)
        {
            var list = new List<T>();
            T[] collection;

            DataPage page = DataPage.First;

            do
            {
                collection = func(page, arg1, arg2).ToArray();

                list.AddRange(collection);

                page = page.Next();

                //NOTE: Don't try to fetch more records if we know there aren't any more.
                if (collection.Length < DataPage.MaxSize)
                    break;
            } while (collection.Length > 0);

            return list;
        }

        public static IEnumerable<T> GetAllPages<T, T1, T2, T3, T4>(Func<DataPage, T1, T2, string, bool, IEnumerable<T>> func, T1 arg1,
                                                           T2 arg2, string orderBy, bool asc)
        {
            var list = new List<T>();
            T[] collection;

            DataPage page = DataPage.First;

            do
            {
                collection = func(page, arg1, arg2, orderBy, asc).ToArray();

                list.AddRange(collection);

                page = page.Next();

                //NOTE: Don't try to fetch more records if we know there aren't any more.
                if (collection.Length < DataPage.MaxSize)
                    break;
            } while (collection.Length > 0);

            return list;
        }
    }
}