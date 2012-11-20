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
using CookComputing.XmlRpc;
using InfusionSoft.Definition;

namespace InfusionSoft
{
    internal class InfusionsoftProxy<TService> where TService : IServiceDefinition
    {
        private const string UriMask = "https://{0}.infusionsoft.com/api/xmlrpc";
        private const string UserAgent = "InfusionSoft .NET SDK";
        private readonly IInfusionSoftConfiguration _configuration;
        private readonly Uri _uri;

        public InfusionsoftProxy(IInfusionSoftConfiguration configuration)
        {
            _configuration = configuration;
            _uri = new Uri(string.Format(UriMask, _configuration.ApplicationName));
        }

        public TResponse Invoke<TResponse>(Func<TService, TResponse> method)
        {
            using (ProxyManager<TService> manager = CreateProxyManager())
            {
                return method(manager);
            }
        }

        public TResponse Invoke<TDefinitionResponse, TResponse>(Func<TService, TDefinitionResponse> method)
        {
            TResponse response = default(TResponse);

            XmlRpcResponseEventHandler responseHandler = (sender, args) =>
            {
                var deserializer1 = new XmlRpcResponseDeserializer();
                XmlRpcResponse res = deserializer1.DeserializeResponse(args.ResponseStream, typeof (TResponse));
                response = (TResponse) res.retVal;
            };

            using (ProxyManager<TService> manager = CreateProxyManager(responseHandler))
            {
                method(manager);
            }

            return response;
        }

        private ProxyManager<TService> CreateProxyManager(XmlRpcResponseEventHandler responseHandler = null)
        {
            var definition = XmlRpcProxyGen.Create<TService>();

// ReSharper disable PossibleInvalidCastException
            var proxy = (IXmlRpcProxy) definition;
// ReSharper restore PossibleInvalidCastException

            proxy.AttachLogger(new XmlRpcDebugLogger());

            proxy.Url = _uri.AbsoluteUri;
            proxy.UserAgent = UserAgent;

            return new ProxyManager<TService>(definition, responseHandler);
        }

        #region Nested type: ProxyManager

        private class ProxyManager<T> : IDisposable
        {
            private readonly IXmlRpcProxy _proxy;
            private readonly XmlRpcResponseEventHandler _responseHandler;

            public ProxyManager(T proxy, XmlRpcResponseEventHandler responseHandler)
            {
                _proxy = (IXmlRpcProxy) proxy;
                _responseHandler = responseHandler;

                if (_responseHandler != null)
                    _proxy.ResponseEvent += _responseHandler;
            }

            #region IDisposable Members

            public void Dispose()
            {
                if (_responseHandler != null)
                    _proxy.ResponseEvent -= _responseHandler;
            }

            #endregion

            public static implicit operator T(ProxyManager<T> wrapper)
            {
                return (T) wrapper._proxy;
            }
        }

        #endregion
    }
}