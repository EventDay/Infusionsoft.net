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
    public class InvoiceItem : ITable
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("InvoiceId")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int InvoiceId { get; set; }

        [XmlRpcMember("OrderItemId")]
        [Access(Access.Read)]
        public int OrderItemId { get; set; }

        [XmlRpcMember("InvoiceAmt")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public double InvoiceAmt { get; set; }

        [XmlRpcMember("Discount")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public double Discount { get; set; }

        [XmlRpcMember("DateCreated")]
        [Access(Access.Read)]
        public string DateCreated { get; set; }

        [XmlRpcMember("Description")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Description { get; set; }

        [XmlRpcMember("CommissionStatus")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int CommissionStatus { get; set; }
    }
}