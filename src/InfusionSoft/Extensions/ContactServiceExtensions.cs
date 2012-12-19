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
using InfusionSoft.Tables;

namespace InfusionSoft
{
    public static class ContactServiceExtensions
    {
        public static int Add(this IContactService service, Action<IFieldSetter<Contact>> fieldSetter)
        {
            var setter = new TableFieldSetter<Contact>(Access.Add);
            fieldSetter(setter);

            return service.Add(setter.XmlStruct);
        }

        public static int AddWithDupCheck(this IContactService service, Action<IFieldSetter<Contact>> fieldSetter,
                                          DupCheckType checkType)
        {
            var setter = new TableFieldSetter<Contact>(Access.Add);
            fieldSetter(setter);

            return service.AddWithDupCheck(setter.XmlStruct, checkType.ToString());
        }

        public static Contact Load(this IContactService service, int id, Action<IProjection<Contact>> projection)
        {
            var contactProjection = new Projection<Contact>();
            projection(contactProjection);

            return service.Load(id, contactProjection.Build());
        }

        public static IEnumerable<Contact> FindByEmail(this IContactService service, string email)
        {
            return FindByEmail(service, email, p => p.IncludeAll());
        }

        public static IEnumerable<Contact> FindByEmail(this IContactService service, string email,
                                                       Action<IProjection<Contact>> fieldSelection)
        {
            var projection = new Projection<Contact>();
            fieldSelection(projection);

            return service.FindByEmail(email, projection.Build());
        }


        public static int Update(this IContactService service, int contactId, Action<IFieldSetter<Contact>> setter)
        {
            var fieldSetter = new TableFieldSetter<Contact>(Access.Edit);
            setter(fieldSetter);

            return service.Update(contactId, fieldSetter.XmlStruct);
        }

        public static IEnumerable<Contact> GetByTag(this IContactService service, int tagId,
                                                    Action<IQueryBuilder<Contact>> queryBuilder,
                                                    Action<IProjection<Contact>> projection)
        {
            IMethodListener listener = service.MethodListenerProvider.GetListener();

            var serviceAccessor = new InfusionSoftClient(service.Configuration)
                                  {
                                      MethodListener = listener
                                  };
            
            IDataService dataService = serviceAccessor.DataService;

            var results = new HashSet<Contact>(Contact.IdComparer);

            results.UnionWith(dataService.Query(query =>
            {
                query.Add(c => c.Groups, string.Format("{0}", tagId), ValuePosition.Default);
                queryBuilder(query);
            }, projection));

            results.UnionWith(dataService.Query(query =>
            {
                query.Add(c => c.Groups, string.Format("{0},", tagId), ValuePosition.StartsWith);
                queryBuilder(query);
            }, projection));

            results.UnionWith(dataService.Query(query =>
            {
                query.Add(c => c.Groups, string.Format(",{0},", tagId), ValuePosition.Contains);
                queryBuilder(query);
            }, projection));

            results.UnionWith(dataService.Query(query =>
            {
                query.Add(c => c.Groups, string.Format(",{0}", tagId), ValuePosition.EndsWith);
                queryBuilder(query);
            }, projection));

            return results;
        }

        public static IEnumerable<Contact> GetByTag(this IContactService service, int tagId,
                                                    Action<IProjection<Contact>> projection)
        {
            return GetByTag(service, tagId, q => { }, projection);
        }
    }
}