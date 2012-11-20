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

namespace InfusionSoft.Definition
{
    public interface IShippingServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("ShippingService.getAllShippingOptions")]
        object GetAllShippingOptions(string key);

        [XmlRpcMethod("ShippingService.getFlatRateShippingOption")]
        object GetFlatRateShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderTotalShippingOption")]
        object GetOrderTotalShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderTotalShippingRanges")]
        object GetOrderTotalShippingRanges(string key, int optionId);

        [XmlRpcMethod("ShippingService.getProductShippingPricesForProductShippingOption")]
        object GetProductShippingPricesForProductShippingOption(string key, int id);

        [XmlRpcMethod("ShippingService.getProductBasedShippingOption")]
        object GetProductBasedShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderQuantityShippingOption")]
        object GetOrderQuantityShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getWeightBasedShippingOption")]
        object GetWeightBasedShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getWeightBasedShippingRanges")]
        object GetWeightBasedShippingRanges(string key, int id);

        [XmlRpcMethod("ShippingService.getUpsShippingOption")]
        object GetUpsShippingOption(string key, int optionId);
    }
}