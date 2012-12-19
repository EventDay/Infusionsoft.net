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
    public class Referral : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("AffiliateId")]
        [Access(Access.Add | Access.Read)]
        public int AffiliateId { get; set; }

        [XmlRpcMember("DateSet")]
        [Access(Access.Add | Access.Read)]
        public string DateSet { get; set; }

        [XmlRpcMember("DateExpires")]
        [Access(Access.Add | Access.Read)]
        public string DateExpires { get; set; }

        [XmlRpcMember("IPAddress")]
        [Access(Access.Add | Access.Read)]
        public string IPAddress { get; set; }

        [XmlRpcMember("Source")]
        [Access(Access.Add | Access.Read)]
        public string Source { get; set; }

        [XmlRpcMember("Info")]
        [Access(Access.Add | Access.Read)]
        public string Info { get; set; }

        [XmlRpcMember("Type")]
        [Access(Access.Add | Access.Read)]
        public int Type { get; set; }
    }
}