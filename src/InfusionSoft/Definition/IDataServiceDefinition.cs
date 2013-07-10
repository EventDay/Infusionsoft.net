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

using System.Collections;
using System.Collections.Generic;
using CookComputing.XmlRpc;

namespace InfusionSoft.Definition
{
    public interface IDataServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("DataService.add")]
        int Add(string key, string table, IDictionary values);

        [XmlRpcMethod("DataService.load")]
        object Load(string key, string table, int recordId, string[] wantedFields);

        [XmlRpcMethod("DataService.update")]
        int Update(string key, string table, int id, object values);

        [XmlRpcMethod("DataService.delete")]
        bool Delete(string key, string table, int id);

        [XmlRpcMethod("DataService.findByField")]
        IEnumerable<object> FindByField(string apiKey, string table, int limit, int page, string fieldName,
                                        object fieldValue,
                                        string[] returnFields);

        [XmlRpcMethod("DataService.query")]
        IEnumerable<object> Query(string apiKey, string table, int limit, int page, IDictionary queryData,
                                  string[] selectedFields);

        [XmlRpcMethod("DataService.query")]
        IEnumerable<object> Query(string apiKey, string table, int limit, int page, IDictionary queryData,
                                  string[] selectedFields, string orderBy, bool asc);

        [XmlRpcMethod("DataService.addCustomField")]
        int AddCustomField(string apiKey, string customFieldType, string displayName, string dataType, int headerId);

        [XmlRpcMethod("DataService.authenticateUser")]
        int AuthenticateUser(string apiKey, string username, string passwordHash);

        [XmlRpcMethod("DataService.getAppSetting")]
        string GetAppSetting(string apiKey, string module, string setting);

        [XmlRpcMethod("DataService.getTemporaryKey")]
        string GetTemporaryKey(string vendorKey, string username, string passwordHash);

        [XmlRpcMethod("DataService.updateCustomField")]
        bool UpdateCustomField(string apiKey, int customFieldId, IDictionary values);
    }
}