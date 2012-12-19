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
    public class Product : Table
    {
        [XmlRpcMember("Id")]
        [Access(Access.Read)]
        public int Id { get; set; }

        [XmlRpcMember("ProductName")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ProductName { get; set; }

        [XmlRpcMember("ProductPrice")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public double ProductPrice { get; set; }

        [XmlRpcMember("Sku")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Sku { get; set; }

        [XmlRpcMember("ShortDescription")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShortDescription { get; set; }

        [XmlRpcMember("Taxable")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int Taxable { get; set; }

        [XmlRpcMember("CountryTaxable")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int CountryTaxable { get; set; }

        [XmlRpcMember("StateTaxable")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int StateTaxable { get; set; }

        [XmlRpcMember("CityTaxable")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int CityTaxable { get; set; }

        [XmlRpcMember("Weight")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public double Weight { get; set; }

        [XmlRpcMember("IsPackage")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int IsPackage { get; set; }

        [XmlRpcMember("NeedsDigitalDelivery")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int NeedsDigitalDelivery { get; set; }

        [XmlRpcMember("Description")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string Description { get; set; }

        [XmlRpcMember("HideInStore")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int HideInStore { get; set; }

        [XmlRpcMember("Status")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int Status { get; set; }

        [XmlRpcMember("TopHTML")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string TopHTML { get; set; }

        [XmlRpcMember("BottomHTML")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string BottomHTML { get; set; }

        [XmlRpcMember("ShippingTime")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string ShippingTime { get; set; }

        [XmlRpcMember("LargeImage")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public object LargeImage { get; set; }

        [XmlRpcMember("InventoryNotifiee")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public string InventoryNotifiee { get; set; }

        [XmlRpcMember("InventoryLimit")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int InventoryLimit { get; set; }

        [XmlRpcMember("Shippable")]
        [Access(Access.Edit | Access.Add | Access.Read)]
        public int Shippable { get; set; }
    }
}