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
    public class ContactAction : ITable
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ContactId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int ContactId { get; set; }

        [XmlRpcMember("OpportunityId")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int OpportunityId { get; set; }

        [XmlRpcMember("ActionType")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ActionType { get; set; }

        [XmlRpcMember("ActionDescription")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ActionDescription { get; set; }

        [XmlRpcMember("CreationDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string CreationDate { get; set; }

        [XmlRpcMember("CreationNotes")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string CreationNotes { get; set; }

        [XmlRpcMember("CompletionDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string CompletionDate { get; set; }

        [XmlRpcMember("ActionDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string ActionDate { get; set; }

        [XmlRpcMember("EndDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string EndDate { get; set; }

        [XmlRpcMember("PopupDate")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public string PopupDate { get; set; }

        [XmlRpcMember("UserID")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int UserID { get; set; }

        [XmlRpcMember("Accepted")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int Accepted { get; set; }

        [XmlRpcMember("CreatedBy")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int CreatedBy { get; set; }

        [XmlRpcMember("LastUpdated")]
        [Access(Access.Read)]
        public string LastUpdated { get; set; }

        [XmlRpcMember("LastUpdatedBy")]
        [Access(Access.Read)]
        public int LastUpdatedBy { get; set; }

        [XmlRpcMember("Priority")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int Priority { get; set; }

        [XmlRpcMember("IsAppointment")]
        [Access(Access.Edit | Access.Delete | Access.Add | Access.Read)]
        public int IsAppointment { get; set; }
    }
}