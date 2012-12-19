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
using System.IO;
using System.Xml;
using CookComputing.XmlRpc;

namespace InfusionSoft.Serialization
{
    public class XmlRpcResponseDeserializer : XmlRpcDeserializer
    {
        public XmlRpcResponse DeserializeResponse(Stream stm, Type svcType)
        {
            if (stm == null)
                throw new ArgumentNullException("stm", "XmlRpcSerializer.DeserializeResponse");
            return DeserializeResponse(XmlRpcXmlReader.Create(stm), svcType);
        }

        public XmlRpcResponse DeserializeResponse(TextReader txtrdr, Type svcType)
        {
            if (txtrdr == null)
                throw new ArgumentNullException("txtrdr", "XmlRpcSerializer.DeserializeResponse");
            return DeserializeResponse(XmlRpcXmlReader.Create(txtrdr), svcType);
        }

        public XmlRpcResponse DeserializeResponse(XmlReader rdr, Type returnType)
        {
            try
            {
                IEnumerator<Node> enumerator = new XmlRpcParser().ParseResponse(rdr).GetEnumerator();
                enumerator.MoveNext();
                if (enumerator.Current is FaultNode)
                    throw DeserializeFault(enumerator);
                if (returnType == typeof (void) || !enumerator.MoveNext())
                {
                    return new XmlRpcResponse
                           {
                               retVal = null
                           };
                }
                Node current = enumerator.Current;
                object obj = MapValueNode(enumerator, returnType, new MappingStack("response"), MappingAction.Error);
                return new XmlRpcResponse
                       {
                           retVal = obj
                       };
            }
            catch (XmlException ex)
            {
                throw new XmlRpcIllFormedXmlException("Response contains invalid XML", ex);
            }
        }

        private XmlRpcException DeserializeFault(IEnumerator<Node> iter)
        {
            var parseStack = new MappingStack("fault response");
            throw ParseFault(iter, parseStack, MappingAction.Error);
        }

        private XmlRpcFaultException ParseFault(IEnumerator<Node> iter, MappingStack parseStack,
                                                MappingAction mappingAction)
        {
            iter.MoveNext();
            Type mappedType;
            var xmlRpcStruct = MapHashtable(iter, null, parseStack, mappingAction, out mappedType) as XmlRpcStruct;
            
            object obj1 = xmlRpcStruct["faultCode"];
            object obj2 = xmlRpcStruct["faultString"];
            if (obj1 is string)
            {
                int result;
                if (!int.TryParse(obj1 as string, out result))
                    throw new XmlRpcInvalidXmlRpcException("faultCode not int or string");
                obj1 = result;
            }
            return new XmlRpcFaultException((int)obj1, (string)obj2);

        }
    }
}