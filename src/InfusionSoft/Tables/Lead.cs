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
using CookComputing.XmlRpc;

namespace InfusionSoft.Tables
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Lead : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("OpportunityTitle")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string OpportunityTitle { get; set; }

        [XmlRpcMember("ContactID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int ContactID { get; set; }

        [XmlRpcMember("AffiliateId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int AffiliateId { get; set; }

        [XmlRpcMember("UserID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int UserID { get; set; }

        [XmlRpcMember("StageID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int StageID { get; set; }

        [XmlRpcMember("StatusID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int StatusID { get; set; }

        [XmlRpcMember("Leadsource")]
        [Access(Access.Add | Access.Read)]
        public string Leadsource { get; set; }

        [XmlRpcMember("Objection")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Objection { get; set; }

        [XmlRpcMember("ProjectedRevenueLow")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public double ProjectedRevenueLow { get; set; }

        [XmlRpcMember("ProjectedRevenueHigh")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public double ProjectedRevenueHigh { get; set; }

        [XmlRpcMember("OpportunityNotes")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string OpportunityNotes { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Edit | Access.Delete | Access.Read)]
        public DateTime DateCreated { get; set; }

        [XmlRpcMember("LastUpdated")]
        [Access(Access.Edit | Access.Delete | Access.Read)]
        public string LastUpdated { get; set; }

        [XmlRpcMember("LastUpdatedBy")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int LastUpdatedBy { get; set; }

        [XmlRpcMember("CreatedBy")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int CreatedBy { get; set; }

        [XmlRpcMember("EstimatedCloseDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string EstimatedCloseDate { get; set; }

        [XmlRpcMember("NextActionDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string NextActionDate { get; set; }

        [XmlRpcMember("NextActionNotes")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string NextActionNotes { get; set; }
    }
}