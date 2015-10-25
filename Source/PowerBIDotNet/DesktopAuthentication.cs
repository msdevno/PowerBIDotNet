using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PowerBIDotNet
{
    public class DesktopAuthentication : IAuthentication
    {
        // https://auth0.com/docs/connections/enterprise/azure-active-directory

        const string AuthorityUri = "https://login.windows.net/common/oauth2/authorize";
        const string RedirectUri = "https://login.live.com/oauth20_desktop.srf";
        const string ResourceUri = "https://analysis.windows.net/powerbi/api";

        IConfigurationForTenants _configurationForTenants;

        public DesktopAuthentication(IConfigurationForTenants configurationForTenants)
        {
            _configurationForTenants = configurationForTenants;
        }

        public void AuthenticateFor(Tenant tenant)
        {
            var configuration = _configurationForTenants.GetFor(tenant);

            var tokenCache = new TokenCache();
            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var result = authenticationContext.AcquireToken(ResourceUri, configuration.Client, new Uri(RedirectUri), PromptBehavior.RefreshSession);

            configuration.AuthorizationToken = result.AccessToken;
            configuration.RefreshToken = result.RefreshToken;

            _configurationForTenants.Save(configuration);
        }

        public void RefreshTokenFor(Tenant tenant)
        {
            var configuration = _configurationForTenants.GetFor(tenant);

            var tokenCache = new TokenCache();
            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var result = authenticationContext.AcquireTokenByRefreshToken(configuration.RefreshToken, configuration.Client, ResourceUri);
            configuration.AuthorizationToken = result.AccessToken;
            _configurationForTenants.Save(configuration);
        }
    }
}
