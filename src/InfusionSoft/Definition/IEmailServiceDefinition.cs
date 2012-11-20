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
    public interface IEmailServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("APIEmailService.addEmailTemplate")]
        int AddEmailTemplate(string apiKey, string pieceTitle, string categories, string toAddress, string ccAddress,
                             string bccAddress, string subject, string textBody, string htmlBody, string contentType,
                             string mergeContext);

        [XmlRpcMethod("APIEmailService.attachEmail")]
        bool AttachEmail(string apiKey, int contactId, string fromName, string fromAddress, string toAddress,
                         string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody,
                         string textBody, string header, string receivedDate, string sentDate, int emailSentType);

        [XmlRpcMethod("APIEmailService.getAvailableMergeFields")]
        string[] GetAvailableMergeFields(string apiKey, string mergeContext);

        [XmlRpcMethod("APIEmailService.getEmailTemplate")]
        EmailTemplate GetEmailTemplate(string apiKey, int templateId);

        [XmlRpcMethod("APIEmailService.getOptStatus")]
        int GetOptStatus(string apiKey, string email);

        [XmlRpcMethod("APIEmailService.optIn")]
        bool OptIn(string apiKey, string email, string optInReason);

        [XmlRpcMethod("APIEmailService.optOut")]
        bool OptOut(string apiKey, string email, string optOutreason);

        [XmlRpcMethod("APIEmailService.sendEmail")]
        bool SendEmail(string apiKey, int[] contactList, string fromAddress, string toAddress, string ccAddresses,
                       string bccAddresses, string contentType, string subject, string htmlBody, string textBody,
                       int templateId);

        [XmlRpcMethod("APIEmailService.sendTemplate")]
        bool SendTemplate(string apiKey, int[] contactList, string templateId);

        [XmlRpcMethod("APIEmailService.updateEmailTemplate")]
        bool UpdateEmailTemplate(string apiKey, int templateId, string pieceTitle, string category,
                                 string fromAddress, string toAddress, string ccAddress, string bccAddresses,
                                 string subject, string textBody, string htmlBody, string contentType,
                                 string mergeContext);
    }
}