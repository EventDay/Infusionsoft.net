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
    public class Invoice : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("JobId")]
        [Access(Access.Read)]
        public int JobId { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public DateTime DateCreated { get; set; }

        [XmlRpcMember("InvoiceTotal")]
        [Access(Access.Read)]
        public double InvoiceTotal { get; set; }

        [XmlRpcMember("TotalPaid")]
        [Access(Access.Read)]
        public double TotalPaid { get; set; }

        [XmlRpcMember("TotalDue")]
        [Access(Access.Read)]
        public double TotalDue { get; set; }

        [XmlRpcMember("PayStatus")]
        [Access(Access.Read)]
        public int PayStatus { get; set; }

        [XmlRpcMember("CreditStatus")]
        [Access(Access.Read)]
        public int CreditStatus { get; set; }

        [XmlRpcMember("RefundStatus")]
        [Access(Access.Read)]
        public int RefundStatus { get; set; }

        [XmlRpcMember("PayPlanStatus")]
        [Access(Access.Read)]
        public int PayPlanStatus { get; set; }

        [XmlRpcMember("AffiliateId")]
        [Access(Access.Read)]
        public int AffiliateId { get; set; }

        [XmlRpcMember("LeadAffiliateId")]
        [Access(Access.Read)]
        public int LeadAffiliateId { get; set; }

        [XmlRpcMember("PromoCode")]
        [Access(Access.Read)]
        public string PromoCode { get; set; }

        [XmlRpcMember("InvoiceType")]
        [Access(Access.Read)]
        public string InvoiceType { get; set; }

        [XmlRpcMember("Description")]
        [Access(Access.Read)]
        public string Description { get; set; }

        [XmlRpcMember("ProductSold")]
        [Access(Access.Read)]
        public string ProductSold { get; set; }

        [XmlRpcMember("Synced")]
        [Access(Access.Read)]
        public bool Synced { get; set; }
    }
}