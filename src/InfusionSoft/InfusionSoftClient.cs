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

using System.Net;

namespace InfusionSoft
{
    internal class InfusionSoftClient : IInfusionSoftClient, IMethodListenerProvider
    {
        private IMethodListener _methodListener;

        public InfusionSoftClient(IInfusionSoftConfiguration configuration)
        {
            Configuration = configuration;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslpolicyerrors) => true;
            
            //Workaround for infusionsoft change.
            //http://community.infusionsoft.com/showthread.php/15371-The-request-was-aborted-Could-not-create-SSL-TLS-secure-channel
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            ApplicationName = configuration.ApplicationName;
            MethodListener = new NullMethodListener();

            AffiliateService = new AffiliateServiceWrapper(configuration, this);
            ContactService = new ContactServiceWrapper(configuration, this);
            DataService = new CustomDataServiceWrapper(configuration, this);
            DiscountService = new DiscountServiceWrapper(configuration, this);
            EmailService = new EmailServiceWrapper(configuration, this);
            InvoiceService = new InvoiceServiceWrapper(configuration, this);
            FileService = new FileServiceWrapper(configuration, this);
            OrderService = new OrderServiceWrapper(configuration, this);
            ProductService = new ProductServiceWrapper(configuration, this);
            SearchService = new SearchServiceWrapper(configuration, this);
            ShippingService = new ShippingServiceWrapper(configuration, this);
            WebFormService = new WebFormServiceWrapper(configuration, this);
            FunnelService = new FunnelServiceWrapper(configuration, this);
        }

        #region IInfusionSoftClient Members

        public IContactService ContactService { get; private set; }

        public IDataService DataService { get; private set; }

        public IEmailService EmailService { get; private set; }

        public IInvoiceService InvoiceService { get; private set; }

        public string ApplicationName { get; private set; }

        public IAffiliateService AffiliateService { get; private set; }

        public IDiscountService DiscountService { get; private set; }

        public IFileService FileService { get; private set; }

        public IFunnelService FunnelService { get; private set; }

        public IOrderService OrderService { get; private set; }

        public IProductService ProductService { get; private set; }

        public ISearchService SearchService { get; private set; }

        public IShippingService ShippingService { get; private set; }

        public IWebFormService WebFormService { get; private set; }

        public IMethodListener MethodListener
        {
            get { return _methodListener; }
            set
            {
                if (value == null)
                    _methodListener = new NullMethodListener();
                _methodListener = value;
            }
        }

        #endregion

        public IInfusionSoftConfiguration Configuration { get; private set; }

        IMethodListener IMethodListenerProvider.GetListener()
        {
            return MethodListener;
        }
    }
}