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

using System.Collections;
using CookComputing.XmlRpc;
using InfusionSoft.Tables;

namespace InfusionSoft.Definition
{
    public interface IContactServiceDefinition : IServiceDefinition
    {
        [XmlRpcMethod("ContactService.add")]
        int Add(string key, IDictionary data);

        [XmlRpcMethod("ContactService.addToCampaign")]
        bool AddToCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.addToGroup")]
        bool AddToGroup(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.getNextCampaignStep")]
        int GetNextCampaignStep(string key, int contactId, int followUpSequenceId);

        [XmlRpcMethod("ContactService.findByEmail")]
        Contact[] FindByEmail(string key, string email, string[] selectedFields);

        [XmlRpcMethod("ContactService.load")]
        Contact Load(string key, int contactId, string[] selectedFields);

        [XmlRpcMethod("ContactService.pauseCampaign")]
        bool PauseCampaign(string key, int contactId, int sequenceId);

        [XmlRpcMethod("ContactService.removeFromCampaign")]
        bool RemoveFromCampaign(string key, int contactId, int followUpSequenceId);

        [XmlRpcMethod("ContactService.removeFromGroup")]
        bool RemoveFromGroup(string key, int contactId, int tagId);

        [XmlRpcMethod("ContactService.resumeCampaignForContact")]
        bool ResumeCampaignForContact(string apiKey, int contactId, int seqId);

        [XmlRpcMethod("ContactService.rescheduleCampaignStep")]
        int RescheduleCampaignStep(string apiKey, int[] contactIds, int sequenceStepId);

        [XmlRpcMethod("ContactService.runActionSequence")]
        RunActionSequenceResult[] RunActionSequence(string apiKey, int contactId, int actionSetId);

        [XmlRpcMethod("ContactService.addWithDupCheck")]
        int AddWithDupCheck(string apiKey, IDictionary data, string dupCheckType);

        [XmlRpcMethod("ContactService.update")]
        int Update(string apiKey, int contactId, IDictionary data);
    }
}