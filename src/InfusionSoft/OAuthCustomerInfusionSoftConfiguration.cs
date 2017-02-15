using System;

namespace InfusionSoft
{
    internal class OAuthCustomerInfusionSoftConfiguration : IInfusionSoftConfiguration
    {
        public OAuthCustomerInfusionSoftConfiguration(string appName, string accessToken)
        {
            ApplicationName = appName.ToLowerInvariant();
            AccessToken = accessToken;
        }

        public string AccessToken { get; private set; }

        private Uri _Uri;

        #region IInfusionSoftConfiguration Members

        public string ApplicationName { get; private set; }

        public virtual string GetApiKey()
        {
            return String.Empty;
        }

        public Uri GetApiUri()
        {
            if (_Uri == null)
            {
                _Uri = new Uri($"https://api.infusionsoft.com/crm/xmlrpc/v1?access_token={AccessToken}");
            }

            return _Uri;
        }

        #endregion IInfusionSoftConfiguration Members
    }
}