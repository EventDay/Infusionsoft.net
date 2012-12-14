using System;

namespace InfusionSoft
{
    internal class VendorInfusionSoftConfiguration : CustomerInfusionSoftConfiguration
    {
        private readonly Func<string> _apiKeyRefresh;
        private DateTime _expirationDate;

        public VendorInfusionSoftConfiguration(string appName, string key, Func<string> apiKeyRefresh) : base(appName, key)
        {
            _apiKeyRefresh = apiKeyRefresh;
            _expirationDate = DateTime.UtcNow.AddMinutes(55);
        }

        public override string GetApiKey()
        {
            if (DateTime.UtcNow >= _expirationDate)
            {
                _expirationDate = DateTime.UtcNow.AddMinutes(55);
                ApiKey = _apiKeyRefresh();
            }
            return ApiKey;
        }
    }
}