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
    internal abstract class ServiceBase<TServiceDefinition> where TServiceDefinition : IServiceDefinition
    {
        private readonly InfusionsoftProxy<TServiceDefinition> _proxy;

        protected ServiceBase(IInfusionSoftConfiguration configuration, IMethodListenerProvider listenerProvider)
        {
            MethodListenerProvider = listenerProvider;
            Configuration = configuration;
            _proxy = new InfusionsoftProxy<TServiceDefinition>(configuration, listenerProvider);
            ApiKey = configuration.ApiKey;
        }

        public IInfusionSoftConfiguration Configuration { get; set; }
        public string ApiKey { get; private set; }

        protected T Invoke<T>(Func<TServiceDefinition, T> method)
        {
            return TryInvoke(() => _proxy.Invoke(method));
        }

        /// <summary>
        ///     This should only be used on dynamic return types as it is a lot slower.
        ///     Typically only used in the Data Service because you can return any entity from any table.
        /// </summary>
        /// <typeparam name="TDefinitionResponse"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        protected internal TResponse Invoke<TDefinitionResponse, TResponse>(
            Func<TServiceDefinition, TDefinitionResponse> method)
        {
            return TryInvoke(() => _proxy.Invoke<TDefinitionResponse, TResponse>(method));
        }

        private static T TryInvoke<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (XmlRpcFaultException e)
            {
                throw new InfusionSoftException(e.Message);
            }
        }

        public IMethodListenerProvider MethodListenerProvider { get; private set; }
    }
}