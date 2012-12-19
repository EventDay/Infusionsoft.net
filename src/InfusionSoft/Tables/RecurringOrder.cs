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
    public class RecurringOrder : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("OriginatingOrderId")]
        [Access(Access.Read)]
        public int OriginatingOrderId { get; set; }

        [XmlRpcMember("ProgramId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int ProgramId { get; set; }

        [XmlRpcMember("SubscriptionPlanId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int SubscriptionPlanId { get; set; }

        [XmlRpcMember("ProductId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int ProductId { get; set; }

        [XmlRpcMember("StartDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string StartDate { get; set; }

        [XmlRpcMember("EndDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string EndDate { get; set; }

        [XmlRpcMember("LastBillDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string LastBillDate { get; set; }

        [XmlRpcMember("NextBillDate")]
        [Access(Access.Read)]
        public string NextBillDate { get; set; }

        [XmlRpcMember("PaidThruDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string PaidThruDate { get; set; }

        [XmlRpcMember("BillingCycle")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BillingCycle { get; set; }

        [XmlRpcMember("Frequency")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int Frequency { get; set; }

        [XmlRpcMember("BillingAmt")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public double BillingAmt { get; set; }

        [XmlRpcMember("Status")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Status { get; set; }

        [XmlRpcMember("ReasonStopped")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ReasonStopped { get; set; }

        [XmlRpcMember("AutoCharge")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int AutoCharge { get; set; }

        [XmlRpcMember("CC1")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int CC1 { get; set; }

        [XmlRpcMember("CC2")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int CC2 { get; set; }

        [XmlRpcMember("NumDaysBetweenRetry")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int NumDaysBetweenRetry { get; set; }

        [XmlRpcMember("MaxRetry")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int MaxRetry { get; set; }

        [XmlRpcMember("MerchantAccountId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int MerchantAccountId { get; set; }

        [XmlRpcMember("AffiliateId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int AffiliateId { get; set; }

        [XmlRpcMember("PromoCode")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string PromoCode { get; set; }

        [XmlRpcMember("LeadAffiliateId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int LeadAffiliateId { get; set; }

        [XmlRpcMember("Qty")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int Qty { get; set; }
    }
}