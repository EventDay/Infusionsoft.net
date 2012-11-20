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
    public interface IDiscountServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("DiscountService.addFreeTrial")]
        object AddFreeTrial(string apiKey, string name, string description, int freeTrialDays, int hidePrice,
                            int subscriptionPlanId);

        [XmlRpcMethod("DiscountService.getFreeTrial")]
        object GetFreeTrial(string apiKey, int trialId);

        [XmlRpcMethod("DiscountService.addOrderTotalDiscount")]
        object AddOrderTotalDiscount(string apiKey, string name, string description, int applyDiscountToCommission,
                                     int percentOrAmt,
                                     int amt, string payType);

        [XmlRpcMethod("DiscountService.getOrderTotalDiscount")]
        object GetOrderTotalDiscount(string apiKey, int id);

        [XmlRpcMethod("DiscountService.addCategoryDiscount")]
        object AddCategoryDiscount(string apiKey, string name, string description, int applyDiscountToCommission,
                                   int amt);

        [XmlRpcMethod("DiscountService.getCategoryDiscount")]
        object GetCategoryDiscount(string apiKey, int id);

        [XmlRpcMethod("DiscountService.addCategoryAssignmentToCategoryDiscount")]
        object AddCategoryAssignmentToCategoryDiscount(string apiKey, int id, int productId);

        [XmlRpcMethod("DiscountService.getCategoryAssignmentsForCategoryDiscount")]
        object GetCategoryAssignmentsForCategoryDiscount(string apiKey, int id);

        [XmlRpcMethod("DiscountService.addProductTotalDiscount")]
        object AddProductTotalDiscount(string apiKey, string name, string description, int applyDiscountToCommission,
                                       int productId,
                                       int percentOrAmt, int amt);

        [XmlRpcMethod("DiscountService.getProductTotalDiscount")]
        object GetProductTotalDiscount(string apiKey, string id);

        [XmlRpcMethod("DiscountService.addShippingTotalDiscount")]
        object AddShippingTotalDiscount(string apiKey, string name, string description, int applyDiscountToCommission,
                                        int percentOrAmt,
                                        int amt);

        [XmlRpcMethod("DiscountService.getShippingTotalDiscount")]
        object GetShippingTotalDiscount(string apiKey, int id);
    }
}