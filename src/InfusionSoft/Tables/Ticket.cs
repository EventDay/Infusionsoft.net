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
    public class Ticket : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("IssueId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int IssueId { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("UserId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int UserId { get; set; }

        [XmlRpcMember("DevId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int DevId { get; set; }

        [XmlRpcMember("TicketTitle")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string TicketTitle { get; set; }

        [XmlRpcMember("TicketApplication")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string TicketApplication { get; set; }

        [XmlRpcMember("TicketCategory")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int TicketCategory { get; set; }

        [XmlRpcMember("TicketTypeId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int TicketTypeId { get; set; }

        [XmlRpcMember("Summary")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string Summary { get; set; }

        [XmlRpcMember("Stage")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int Stage { get; set; }

        [XmlRpcMember("Priority")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int Priority { get; set; }

        [XmlRpcMember("Ordering")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int Ordering { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public string DateCreated { get; set; }

        [XmlRpcMember("CreatedBy")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int CreatedBy { get; set; }

        [XmlRpcMember("LastUpdated")]
        [Access(Access.Read)]
        public string LastUpdated { get; set; }

        [XmlRpcMember("LastUpdatedBy")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int LastUpdatedBy { get; set; }

        [XmlRpcMember("CloseDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string CloseDate { get; set; }

        [XmlRpcMember("FolowUpDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string FolowUpDate { get; set; }

        [XmlRpcMember("TargetCompletionDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string TargetCompletionDate { get; set; }

        [XmlRpcMember("DateInStage")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string DateInStage { get; set; }

        [XmlRpcMember("TimeSpent")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public double TimeSpent { get; set; }

        [XmlRpcMember("HasCustomerCalled")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int HasCustomerCalled { get; set; }
    }
}