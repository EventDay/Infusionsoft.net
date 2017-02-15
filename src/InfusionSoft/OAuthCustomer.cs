using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfusionSoft
{
    public class OAuthCustomer : Customer
    {
        private readonly string _accessToken;

        public OAuthCustomer(string application, string accessToken)
            : base(application: application, apiKey: string.Empty)
        {
            _accessToken = accessToken;
        }

        public override IInfusionSoftClient Connect()
        {
            var configuration = new OAuthCustomerInfusionSoftConfiguration(_application, _accessToken);
            return new InfusionSoftClient(configuration);
        }
    }
}
