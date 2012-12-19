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
    public class CreditCard : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("BillName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillName { get; set; }

        [XmlRpcMember("FirstName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string FirstName { get; set; }

        [XmlRpcMember("LastName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string LastName { get; set; }

        [XmlRpcMember("PhoneNumber")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string PhoneNumber { get; set; }

        [XmlRpcMember("Email")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Email { get; set; }

        [XmlRpcMember("BillAddress1")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillAddress1 { get; set; }

        [XmlRpcMember("BillAddress2")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillAddress2 { get; set; }

        [XmlRpcMember("BillCity")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillCity { get; set; }

        [XmlRpcMember("BillState")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillState { get; set; }

        [XmlRpcMember("BillZip")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillZip { get; set; }

        [XmlRpcMember("BillCountry")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillCountry { get; set; }

        [XmlRpcMember("ShipFirstName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipFirstName { get; set; }

        [XmlRpcMember("ShipMiddleName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipMiddleName { get; set; }

        [XmlRpcMember("ShipLastName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipLastName { get; set; }

        [XmlRpcMember("ShipCompanyName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipCompanyName { get; set; }

        [XmlRpcMember("ShipPhoneNumber")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipPhoneNumber { get; set; }

        [XmlRpcMember("ShipAddress1")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipAddress1 { get; set; }

        [XmlRpcMember("ShipAddress2")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipAddress2 { get; set; }

        [XmlRpcMember("ShipCity")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipCity { get; set; }

        [XmlRpcMember("ShipState")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipState { get; set; }

        [XmlRpcMember("ShipZip")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipZip { get; set; }

        [XmlRpcMember("ShipCountry")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipCountry { get; set; }

        [XmlRpcMember("ShipName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipName { get; set; }

        [XmlRpcMember("NameOnCard")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string NameOnCard { get; set; }

        [XmlRpcMember("CardNumber")]
        [Access(Access.Add)]
        public string CardNumber { get; set; }

        [XmlRpcMember("Last4")]
        [Access(Access.Read)]
        public string Last4 { get; set; }

        [XmlRpcMember("ExpirationMonth")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ExpirationMonth { get; set; }

        [XmlRpcMember("ExpirationYear")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ExpirationYear { get; set; }

        [XmlRpcMember("CVV2")]
        [Access(Access.Edit | Access.Add)]
        public string CVV2 { get; set; }

        [XmlRpcMember("Status")]
        [Access(Access.Read)]
        public int Status { get; set; }

        [XmlRpcMember("CardType")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string CardType { get; set; }

        [XmlRpcMember("StartDateMonth")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string StartDateMonth { get; set; }

        [XmlRpcMember("StartDateYear")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string StartDateYear { get; set; }

        [XmlRpcMember("MaestroIssueNumber")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string MaestroIssueNumber { get; set; }
    }
}