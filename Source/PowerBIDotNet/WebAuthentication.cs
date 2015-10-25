using System;
using System.Web;
using Infrastructure.PowerBI;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PowerBIDotNet
{
    public class WebAuthentication : IAuthentication
    {
        const string ResourceUri = "https://analysis.windows.net/powerbi/api";
        const string AuthorityUri = "https://login.windows.net/common/oauth2/authorize/";

        IConfigurationForTenants _configurationForTenants;

        public WebAuthentication(IConfigurationForTenants configurationForTenants)
        {
            _configurationForTenants = configurationForTenants;
        }


        public void AuthenticateFor(Tenant tenant)
        {
            var context = HttpContext.Current;
            var redirectUri = "http://localhost:30348/Redirect.ashx";
            

            var code = context.Request.Params["code"];

            var configuration = _configurationForTenants.GetFor(tenant);

            // Get auth token from auth code       
            var tokenCache = new TokenCache();

            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var clientCredential = new ClientCredential(configuration.Client, configuration.ClientSecret);

            var result = authenticationContext.AcquireTokenByAuthorizationCode(code, new Uri(redirectUri), clientCredential);

            configuration.RefreshToken = code;
            configuration.AuthorizationToken = result.AccessToken;
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