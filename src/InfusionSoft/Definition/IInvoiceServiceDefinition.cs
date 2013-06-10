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
using System.Collections.Generic;
using CookComputing.XmlRpc;

namespace InfusionSoft.Definition
{
    public interface IInvoiceServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("InvoiceService.createBlankOrder")]
        int CreateBlankOrder(string apiKey, int contactId, string description, DateTime orderDate,
                             int leadAffiliateId, int saleAffiliateId);

        [XmlRpcMethod("InvoiceService.addOrderItem")]
        bool AddOrderItem(string apiKey, int invoiceId, int productId, int type, double price, int quantity,
                          string title, string description);

        [XmlRpcMethod("InvoiceService.chargeInvoice")]
        ChargeInvoiceResult ChargeInvoice(string apiKey, int invoiceId, string notes, int creditCardId,
                                          int merchantAccountId,
                                          bool bypassCommissions);

        [XmlRpcMethod("InvoiceService.deleteSubscription")]
        bool DeleteSubscription(string apiKey, int recurringOrderId);

        [XmlRpcMethod("InvoiceService.addRecurringOrder")]
        int AddRecurringOrder(string apiKey, int contactId, bool allowDuplicate, int cProgramId, int qty,
                              double price, bool taxable, int merchantAccountId, int creditCardId, int affiliateId,
                              int daysTillCharge);

        [XmlRpcMethod("InvoiceService.addRecurringCommissionOverride")]
        bool AddRecurringCommissionOverride(string apiKey, int recurringOrderId, int affiliateId, double amount,
                                            int payoutType, string description);

        [XmlRpcMethod("InvoiceService.createInvoiceForRecurring")]
        int CreateInvoiceForRecurring(string apiKey, int recurringOrderId);

        [XmlRpcMethod("InvoiceService.addManualPayment")]
        bool AddManualPayment(string apiKey, int invoiceId, double amt, DateTime paymentDate, string paymentType,
                              string paymentDescription, bool bypassCommissions);

        [XmlRpcMethod("InvoiceService.addPaymentPlan")]
        bool AddPaymentPlan(string apiKey, int invoiceId, bool autoCharge, int creditCardId, int merchantAccountId,
                            int daysBetweenRetry, int maxRetry, double initialPmtAmt, DateTime initialPmtDate,
                            DateTime planStartDate, int numPmts, int daysBetweenPmts);

        [XmlRpcMethod("InvoiceService.calculateAmountOwed")]
        double CalculateAmountOwed(string apiKey, int invoiceId);

        [XmlRpcMethod("InvoiceService.getAllPaymentOptions")]
        XmlRpcStruct GetAllPaymentOptions(string apiKey);

        [XmlRpcMethod("InvoiceService.getPayments")]
        object GetPayments(string apiKey, int invoiceId);

        [XmlRpcMethod("InvoiceService.locateExistingCard")]
        int LocateExistingCard(string apiKey, int contactId, int last4);

        [XmlRpcMethod("InvoiceService.recalculateTax")]
        bool RecalculateTax(string apiKey, int invoiceId);

        [XmlRpcMethod("InvoiceService.validateCreditCard")]
        UntypedValidateCreditCardResult ValidateCreditCard(string apiKey, int creditCardId);

        [XmlRpcMethod("InvoiceService.validateCreditCard")]
        UntypedValidateCreditCardResult ValidateCreditCard(string apiKey, CreditCardData data);

        [XmlRpcMethod("InvoiceService.getAllShippingOptions")]
        object GetAllShippingOptions(string apiKey);

        [XmlRpcMethod("InvoiceService.updateJobRecurringNextBillDate")]
        bool UpdateJobRecurringNextBillDate(string apiKey, int recurringOrderId, DateTime nextBillDate);

        [XmlRpcMethod("InvoiceService.addOrderCommissionOverride")]
        bool AddOrderCommissionOverride(string apiKey, int invoiceId, int affiliateId, int productId, int percentage,
                                        double amount, int payoutType, string description, DateTime date);

        [XmlRpcMethod("InvoiceService.deleteInvoice")]
        bool DeleteInvoice(string apiKey, int invoiceId);
    }
}