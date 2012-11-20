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
    public class User : ITable
    {
        [XmlRpcMember("City")]
        [Access(Access.Read)]
        public string City { get; set; }

        [XmlRpcMember("Email")]
        [Access(Access.Read)]
        public string Email { get; set; }

        [XmlRpcMember("EmailAddress2")]
        [Access(Access.Read)]
        public string EmailAddress2 { get; set; }

        [XmlRpcMember("EmailAddress3")]
        [Access(Access.Read)]
        public string EmailAddress3 { get; set; }

        [XmlRpcMember("FirstName")]
        [Access(Access.Read)]
        public string FirstName { get; set; }

        [XmlRpcMember("HTMLSignature")]
        [Access(Access.Read)]
        public string HTMLSignature { get; set; }

        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("LastName")]
        [Access(Access.Read)]
        public string LastName { get; set; }

        [XmlRpcMember("MiddleName")]
        [Access(Access.Read)]
        public string MiddleName { get; set; }

        [XmlRpcMember("Nickname")]
        [Access(Access.Read)]
        public string Nickname { get; set; }

        [XmlRpcMember("Phone1")]
        [Access(Access.Read)]
        public string Phone1 { get; set; }

        [XmlRpcMember("Phone1Ext")]
        [Access(Access.Read)]
        public string Phone1Ext { get; set; }

        [XmlRpcMember("Phone1Type")]
        [Access(Access.Read)]
        public string Phone1Type { get; set; }

        [XmlRpcMember("Phone2")]
        [Access(Access.Read)]
        public string Phone2 { get; set; }

        [XmlRpcMember("Phone2Ext")]
        [Access(Access.Read)]
        public string Phone2Ext { get; set; }

        [XmlRpcMember("Phone2Type")]
        [Access(Access.Read)]
        public string Phone2Type { get; set; }

        [XmlRpcMember("PostalCode")]
        [Access(Access.Read)]
        public string PostalCode { get; set; }

        [XmlRpcMember("Signature")]
        [Access(Access.Read)]
        public string Signature { get; set; }

        [XmlRpcMember("SpouseName")]
        [Access(Access.Read)]
        public string SpouseName { get; set; }

        [XmlRpcMember("State")]
        [Access(Access.Read)]
        public string State { get; set; }

        [XmlRpcMember("StreetAddress1")]
        [Access(Access.Read)]
        public string StreetAddress1 { get; set; }

        [XmlRpcMember("StreetAddress2")]
        [Access(Access.Read)]
        public string StreetAddress2 { get; set; }

        [XmlRpcMember("Suffix")]
        [Access(Access.Read)]
        public string Suffix { get; set; }

        [XmlRpcMember("Title")]
        [Access(Access.Read)]
        public string Title { get; set; }

        [XmlRpcMember("ZipFour1")]
        [Access(Access.Read)]
        public string ZipFour1 { get; set; }
    }
}