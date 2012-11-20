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
    public class Job : ITable
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("JobTitle")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string JobTitle { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("StartDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string StartDate { get; set; }

        [XmlRpcMember("DueDate")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string DueDate { get; set; }

        [XmlRpcMember("JobNotes")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string JobNotes { get; set; }

        [XmlRpcMember("ProductId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int ProductId { get; set; }

        [XmlRpcMember("JobStatus")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string JobStatus { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public string DateCreated { get; set; }

        [XmlRpcMember("JobRecurringId")]
        [Access(Access.Read)]
        public int JobRecurringId { get; set; }

        [XmlRpcMember("OrderType")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string OrderType { get; set; }

        [XmlRpcMember("OrderStatus")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int OrderStatus { get; set; }

        [XmlRpcMember("ShipFirstName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipFirstName { get; set; }

        [XmlRpcMember("ShipMiddleName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipMiddleName { get; set; }

        [XmlRpcMember("ShipLastName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipLastName { get; set; }

        [XmlRpcMember("ShipCompany")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipCompany { get; set; }

        [XmlRpcMember("ShipPhone")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipPhone { get; set; }

        [XmlRpcMember("ShipStreet1")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipStreet1 { get; set; }

        [XmlRpcMember("ShipStreet2")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShipStreet2 { get; set; }

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
    }
}