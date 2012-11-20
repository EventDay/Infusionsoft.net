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

using CookComputing.XmlRpc;

namespace InfusionSoft.Tables
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class ContactGroupAssign : ITable
    {
        [XmlRpcMember("GroupId")]
        [Access(Access.Read)]
        public int GroupId { get; set; }

        [XmlRpcMember("ContactGroup")]
        [Access(Access.Read)]
        public string ContactGroup { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public string DateCreated { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("Contact.Address1Type")]
        [Access(Access.Read)]
        public string ContactAddress1Type { get; set; }

        [XmlRpcMember("Contact.Address2Street1")]
        [Access(Access.Read)]
        public string ContactAddress2Street1 { get; set; }

        [XmlRpcMember("Contact.Address2Street2")]
        [Access(Access.Read)]
        public string ContactAddress2Street2 { get; set; }

        [XmlRpcMember("Contact.Address2Type")]
        [Access(Access.Read)]
        public string ContactAddress2Type { get; set; }

        [XmlRpcMember("Contact.Address3Street1")]
        [Access(Access.Read)]
        public string ContactAddress3Street1 { get; set; }

        [XmlRpcMember("Contact.Address3Street2")]
        [Access(Access.Read)]
        public string ContactAddress3Street2 { get; set; }

        [XmlRpcMember("Contact.Address3Type")]
        [Access(Access.Read)]
        public string ContactAddress3Type { get; set; }

        [XmlRpcMember("Contact.Anniversary")]
        [Access(Access.Read)]
        public string ContactAnniversary { get; set; }

        [XmlRpcMember("Contact.AssistantName")]
        [Access(Access.Read)]
        public string ContactAssistantName { get; set; }

        [XmlRpcMember("Contact.AssistantPhone")]
        [Access(Access.Read)]
        public string ContactAssistantPhone { get; set; }

        [XmlRpcMember("Contact.BillingInformation")]
        [Access(Access.Read)]
        public string ContactBillingInformation { get; set; }

        [XmlRpcMember("Contact.Birthday")]
        [Access(Access.Read)]
        public string ContactBirthday { get; set; }

        [XmlRpcMember("Contact.City")]
        [Access(Access.Read)]
        public string ContactCity { get; set; }

        [XmlRpcMember("Contact.City2")]
        [Access(Access.Read)]
        public string ContactCity2 { get; set; }

        [XmlRpcMember("Contact.City3")]
        [Access(Access.Read)]
        public string ContactCity3 { get; set; }

        [XmlRpcMember("Contact.Company")]
        [Access(Access.Read)]
        public string ContactCompany { get; set; }

        [XmlRpcMember("Contact.CompanyID")]
        [Access(Access.Read)]
        public int ContactCompanyID { get; set; }

        [XmlRpcMember("Contact.ContactNotes")]
        [Access(Access.Read)]
        public string ContactContactNotes { get; set; }

        [XmlRpcMember("Contact.ContactType")]
        [Access(Access.Read)]
        public string ContactContactType { get; set; }

        [XmlRpcMember("Contact.Country")]
        [Access(Access.Read)]
        public string ContactCountry { get; set; }

        [XmlRpcMember("Contact.Country2")]
        [Access(Access.Read)]
        public string ContactCountry2 { get; set; }

        [XmlRpcMember("Contact.Country3")]
        [Access(Access.Read)]
        public string ContactCountry3 { get; set; }

        [XmlRpcMember("Contact.CreatedBy")]
        [Access(Access.Read)]
        public int ContactCreatedBy { get; set; }

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDate1")]
		[Access(Access.Read )]
		public string ContactCustomDate1 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDate2")]
		[Access(Access.Read )]
		public string ContactCustomDate2 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDate3")]
		[Access(Access.Read )]
		public string ContactCustomDate3 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDate4")]
		[Access(Access.Read )]
		public string ContactCustomDate4 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDate5")]
		[Access(Access.Read )]
		public string ContactCustomDate5 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDbl1")]
		[Access(Access.Read )]
		public double ContactCustomDbl1 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDbl2")]
		[Access(Access.Read )]
		public double ContactCustomDbl2 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDbl3")]
		[Access(Access.Read )]
		public double ContactCustomDbl3 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDbl4")]
		[Access(Access.Read )]
		public double ContactCustomDbl4 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomDbl5")]
		[Access(Access.Read )]
		public double ContactCustomDbl5 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField1")]
		[Access(Access.Read )]
		public string ContactCustomField1 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField10")]
		[Access(Access.Read )]
		public string ContactCustomField10 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField2")]
		[Access(Access.Read )]
		public string ContactCustomField2 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField3")]
		[Access(Access.Read )]
		public string ContactCustomField3 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField4")]
		[Access(Access.Read )]
		public string ContactCustomField4 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField5")]
		[Access(Access.Read )]
		public string ContactCustomField5 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField6")]
		[Access(Access.Read )]
		public string ContactCustomField6 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField7")]
		[Access(Access.Read )]
		public string ContactCustomField7 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField8")]
		[Access(Access.Read )]
		public string ContactCustomField8 { get; set; }
		*/

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.CustomField9")]
		[Access(Access.Read )]
		public string ContactCustomField9 { get; set; }
		*/

        [XmlRpcMember("Contact.DateCreated")]
        [Access(Access.Read)]
        public string ContactDateCreated { get; set; }

        [XmlRpcMember("Contact.Email")]
        [Access(Access.Read)]
        public string ContactEmail { get; set; }

        [XmlRpcMember("Contact.EmailAddress2")]
        [Access(Access.Read)]
        public string ContactEmailAddress2 { get; set; }

        [XmlRpcMember("Contact.EmailAddress3")]
        [Access(Access.Read)]
        public string ContactEmailAddress3 { get; set; }

        [XmlRpcMember("Contact.Fax1")]
        [Access(Access.Read)]
        public string ContactFax1 { get; set; }

        [XmlRpcMember("Contact.Fax1Type")]
        [Access(Access.Read)]
        public string ContactFax1Type { get; set; }

        [XmlRpcMember("Contact.Fax2")]
        [Access(Access.Read)]
        public string ContactFax2 { get; set; }

        [XmlRpcMember("Contact.Fax2Type")]
        [Access(Access.Read)]
        public string ContactFax2Type { get; set; }

        [XmlRpcMember("Contact.FirstName")]
        [Access(Access.Read)]
        public string ContactFirstName { get; set; }

        [XmlRpcMember("Contact.Groups")]
        [Access(Access.Read)]
        public string ContactGroups { get; set; }

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.HTMLSignature")]
		[Access(Access.Read )]
		public string ContactHTMLSignature { get; set; }
		*/

        [XmlRpcMember("Contact.JobTitle")]
        [Access(Access.Read)]
        public string ContactJobTitle { get; set; }

        [XmlRpcMember("Contact.LastName")]
        [Access(Access.Read)]
        public string ContactLastName { get; set; }

        [XmlRpcMember("Contact.LastUpdated")]
        [Access(Access.Read)]
        public string ContactLastUpdated { get; set; }

        [XmlRpcMember("Contact.LastUpdatedBy")]
        [Access(Access.Read)]
        public string ContactLastUpdatedBy { get; set; }

        [XmlRpcMember("Contact.Leadsource")]
        [Access(Access.Read)]
        public string ContactLeadsource { get; set; }

        [XmlRpcMember("Contact.MiddleName")]
        [Access(Access.Read)]
        public string ContactMiddleName { get; set; }

        [XmlRpcMember("Contact.Nickname")]
        [Access(Access.Read)]
        public string ContactNickname { get; set; }

        [XmlRpcMember("Contact.OwnerID")]
        [Access(Access.Read)]
        public int ContactOwnerID { get; set; }

        [XmlRpcMember("Contact.Phone1")]
        [Access(Access.Read)]
        public string ContactPhone1 { get; set; }

        [XmlRpcMember("Contact.Phone1Ext")]
        [Access(Access.Read)]
        public string ContactPhone1Ext { get; set; }

        [XmlRpcMember("Contact.Phone1Type")]
        [Access(Access.Read)]
        public string ContactPhone1Type { get; set; }

        [XmlRpcMember("Contact.Phone2")]
        [Access(Access.Read)]
        public string ContactPhone2 { get; set; }

        [XmlRpcMember("Contact.Phone2Ext")]
        [Access(Access.Read)]
        public string ContactPhone2Ext { get; set; }

        [XmlRpcMember("Contact.Phone2Type")]
        [Access(Access.Read)]
        public string ContactPhone2Type { get; set; }

        [XmlRpcMember("Contact.Phone3")]
        [Access(Access.Read)]
        public string ContactPhone3 { get; set; }

        [XmlRpcMember("Contact.Phone3Ext")]
        [Access(Access.Read)]
        public string ContactPhone3Ext { get; set; }

        [XmlRpcMember("Contact.Phone3Type")]
        [Access(Access.Read)]
        public string ContactPhone3Type { get; set; }

        [XmlRpcMember("Contact.Phone4")]
        [Access(Access.Read)]
        public string ContactPhone4 { get; set; }

        [XmlRpcMember("Contact.Phone4Ext")]
        [Access(Access.Read)]
        public string ContactPhone4Ext { get; set; }

        [XmlRpcMember("Contact.Phone4Type")]
        [Access(Access.Read)]
        public string ContactPhone4Type { get; set; }

        [XmlRpcMember("Contact.Phone5")]
        [Access(Access.Read)]
        public string ContactPhone5 { get; set; }

        [XmlRpcMember("Contact.Phone5Ext")]
        [Access(Access.Read)]
        public string ContactPhone5Ext { get; set; }

        [XmlRpcMember("Contact.Phone5Type")]
        [Access(Access.Read)]
        public string ContactPhone5Type { get; set; }

        [XmlRpcMember("Contact.PostalCode")]
        [Access(Access.Read)]
        public string ContactPostalCode { get; set; }

        [XmlRpcMember("Contact.PostalCode2")]
        [Access(Access.Read)]
        public string ContactPostalCode2 { get; set; }

        [XmlRpcMember("Contact.PostalCode3")]
        [Access(Access.Read)]
        public string ContactPostalCode3 { get; set; }

        [XmlRpcMember("Contact.ReferralCode")]
        [Access(Access.Read)]
        public string ContactReferralCode { get; set; }

        /* NOTE: This column causes an error to occur on the Infusionsoft Server
		[XmlRpcMember("Contact.Signature")]
		[Access(Access.Read )]
		public string ContactSignature { get; set; }
		*/

        [XmlRpcMember("Contact.SpouseName")]
        [Access(Access.Read)]
        public string ContactSpouseName { get; set; }

        [XmlRpcMember("Contact.State")]
        [Access(Access.Read)]
        public string ContactState { get; set; }

        [XmlRpcMember("Contact.State2")]
        [Access(Access.Read)]
        public string ContactState2 { get; set; }

        [XmlRpcMember("Contact.State3")]
        [Access(Access.Read)]
        public string ContactState3 { get; set; }

        [XmlRpcMember("Contact.StreetAddress1")]
        [Access(Access.Read)]
        public string ContactStreetAddress1 { get; set; }

        [XmlRpcMember("Contact.StreetAddress2")]
        [Access(Access.Read)]
        public string ContactStreetAddress2 { get; set; }

        [XmlRpcMember("Contact.Suffix")]
        [Access(Access.Read)]
        public string ContactSuffix { get; set; }

        [XmlRpcMember("Contact.Title")]
        [Access(Access.Read)]
        public string ContactTitle { get; set; }

        [XmlRpcMember("Contact.Website")]
        [Access(Access.Read)]
        public string ContactWebsite { get; set; }

        [XmlRpcMember("Contact.ZipFour1")]
        [Access(Access.Read)]
        public string ContactZipFour1 { get; set; }

        [XmlRpcMember("Contact.ZipFour2")]
        [Access(Access.Read)]
        public string ContactZipFour2 { get; set; }

        [XmlRpcMember("Contact.ZipFour3")]
        [Access(Access.Read)]
        public string ContactZipFour3 { get; set; }
    }
}