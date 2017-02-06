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
using System.Dynamic;
using CookComputing.XmlRpc;

namespace InfusionSoft.Tables
{
    public abstract class Table : DynamicObject, ITable
    {
        private readonly IDictionary<string, object> _customFields;

        protected Table()
        {
            _customFields = new Dictionary<string, object>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _customFields.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _customFields[binder.Name] = value;
            return true;
        }

        internal void SetCustomField(string name, object value)
        {
            _customFields[name.TrimStart('_')] = value;
        }

        public IDictionary<string, object> CustomFields
        {
            get { return _customFields; }
        }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Contact : Table
    {
        private static readonly IEqualityComparer<Contact> IdComparerInstance = new IdEqualityComparer();

        [XmlRpcMember("Address1Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address1Type { get; set; }

        [XmlRpcMember("Address2Street1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address2Street1 { get; set; }

        [XmlRpcMember("Address2Street2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address2Street2 { get; set; }

        [XmlRpcMember("Address2Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address2Type { get; set; }

        [XmlRpcMember("Address3Street1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address3Street1 { get; set; }

        [XmlRpcMember("Address3Street2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address3Street2 { get; set; }

        [XmlRpcMember("Address3Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Address3Type { get; set; }

        [XmlRpcMember("Anniversary")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public DateTime Anniversary { get; set; }

        [XmlRpcMember("AssistantName")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string AssistantName { get; set; }

        [XmlRpcMember("AssistantPhone")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string AssistantPhone { get; set; }

        [XmlRpcMember("BillingInformation")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string BillingInformation { get; set; }

        [XmlRpcMember("Birthday")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public DateTime Birthday { get; set; }

        [XmlRpcMember("City")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string City { get; set; }

        [XmlRpcMember("City2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string City2 { get; set; }

        [XmlRpcMember("City3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string City3 { get; set; }

        [XmlRpcMember("Company")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Company { get; set; }

        //[XmlRpcMember("AccountId")]
        //[Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        //public int AccountId { get; set; }

        [XmlRpcMember("CompanyID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string CompanyId { get; set; }

        [XmlRpcMember("ContactNotes")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ContactNotes { get; set; }

        [XmlRpcMember("ContactType")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ContactType { get; set; }

        [XmlRpcMember("Country")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Country { get; set; }

        [XmlRpcMember("Country2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Country2 { get; set; }

        [XmlRpcMember("Country3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Country3 { get; set; }

        [XmlRpcMember("CreatedBy")]
        [Access(Access.Read)]
        public string CreatedBy { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public DateTime DateCreated { get; set; }

        [XmlRpcMember("Email")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Email { get; set; }

        [XmlRpcMember("EmailAddress2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string EmailAddress2 { get; set; }

        [XmlRpcMember("EmailAddress3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string EmailAddress3 { get; set; }

        [XmlRpcMember("Fax1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Fax1 { get; set; }

        [XmlRpcMember("Fax1Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Fax1Type { get; set; }

        [XmlRpcMember("Fax2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Fax2 { get; set; }

        [XmlRpcMember("Fax2Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Fax2Type { get; set; }

        [XmlRpcMember("FirstName")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string FirstName { get; set; }

        [XmlRpcMember("Groups")]
        [Access(Access.Read)]
        public string Groups { get; set; }

        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public string Id { get; set; }

        [XmlRpcMember("JobTitle")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string JobTitle { get; set; }

        [XmlRpcMember("LastName")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string LastName { get; set; }

        [XmlRpcMember("LastUpdated")]
        [Access(Access.Read)]
        public DateTime LastUpdated { get; set; }

        [XmlRpcMember("LastUpdatedBy")]
        [Access(Access.Read)]
        public string LastUpdatedBy { get; set; }

        [XmlRpcMember("Leadsource")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Leadsource { get; set; }

        [XmlRpcMember("LeadSourceId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string LeadSourceId { get; set; }

        [XmlRpcMember("MiddleName")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string MiddleName { get; set; }

        [XmlRpcMember("Nickname")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Nickname { get; set; }

        [XmlRpcMember("OwnerID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string OwnerId { get; set; }

        [XmlRpcMember("Password")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Password { get; set; }

        [XmlRpcMember("Phone1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone1 { get; set; }

        [XmlRpcMember("Phone1Ext")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone1Ext { get; set; }

        [XmlRpcMember("Phone1Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone1Type { get; set; }

        [XmlRpcMember("Phone2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone2 { get; set; }

        [XmlRpcMember("Phone2Ext")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone2Ext { get; set; }

        [XmlRpcMember("Phone2Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone2Type { get; set; }

        [XmlRpcMember("Phone3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone3 { get; set; }

        [XmlRpcMember("Phone3Ext")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone3Ext { get; set; }

        [XmlRpcMember("Phone3Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone3Type { get; set; }

        [XmlRpcMember("Phone4")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone4 { get; set; }

        [XmlRpcMember("Phone4Ext")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone4Ext { get; set; }

        [XmlRpcMember("Phone4Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone4Type { get; set; }

        [XmlRpcMember("Phone5")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone5 { get; set; }

        [XmlRpcMember("Phone5Ext")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone5Ext { get; set; }

        [XmlRpcMember("Phone5Type")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Phone5Type { get; set; }

        [XmlRpcMember("PostalCode")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string PostalCode { get; set; }

        [XmlRpcMember("PostalCode2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string PostalCode2 { get; set; }

        [XmlRpcMember("PostalCode3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string PostalCode3 { get; set; }

        [XmlRpcMember("ReferralCode")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ReferralCode { get; set; }

        [XmlRpcMember("SpouseName")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string SpouseName { get; set; }

        [XmlRpcMember("State")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string State { get; set; }

        [XmlRpcMember("State2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string State2 { get; set; }

        [XmlRpcMember("State3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string State3 { get; set; }

        [XmlRpcMember("StreetAddress1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string StreetAddress1 { get; set; }

        [XmlRpcMember("StreetAddress2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string StreetAddress2 { get; set; }

        [XmlRpcMember("Suffix")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Suffix { get; set; }

        [XmlRpcMember("Title")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Title { get; set; }

        [XmlRpcMember("Username")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Username { get; set; }

        [XmlRpcMember("Validated")]
        [Access(Access.Read)]
        public int Validated { get; set; }

        [XmlRpcMember("Website")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Website { get; set; }

        [XmlRpcMember("ZipFour1")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ZipFour1 { get; set; }

        [XmlRpcMember("ZipFour2")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ZipFour2 { get; set; }

        [XmlRpcMember("ZipFour3")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ZipFour3 { get; set; }
        
        public static IEqualityComparer<Contact> IdComparer
        {
            get { return IdComparerInstance; }
        }

        private sealed class IdEqualityComparer : IEqualityComparer<Contact>
        {
            public bool Equals(Contact x, Contact y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(Contact obj)
            {
                var intId = 0;
                var test = Int32.TryParse(obj.Id, out intId);
                return intId;
            }
        }
    }
}