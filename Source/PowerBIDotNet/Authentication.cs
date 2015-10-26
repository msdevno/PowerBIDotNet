using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PowerBIDotNet
{
    public class Authentication : IAuthentication
    {
        // https://auth0.com/docs/connections/enterprise/azure-active-directory

        const string AuthorityUri = "https://login.windows.net/common/oauth2/authorize";
        const string RedirectUri = "https://login.live.com/oauth20_desktop.srf";
        const string ResourceUri = "https://analysis.windows.net/powerbi/api";

        public Tokens GetTokens(Client client)
        {
            var tokenCache = new TokenCache();
            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var result = authenticationContext.AcquireToken(ResourceUri, client, new Uri(RedirectUri), PromptBehavior.RefreshSession);

            var tokens = new Tokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };

            return tokens;
        }

        public Tokens GetTokens(Client client, ClientSecret clientSecret, Token token, string redirectUri)
        {
            var tokenCache = new TokenCache();

            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var clientCredential = new ClientCredential(client, clientSecret);

            var result = authenticationContext.AcquireTokenByAuthorizationCode(token, new Uri(redirectUri), clientCredential);
            var tokens = new Tokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };
            return tokens;
        }

        public Tokens RefreshToken(Client client, Token refreshToken)
        {
            var tokenCache = new TokenCache();
            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var result = authenticationContext.AcquireTokenByRefreshToken(refreshToken, client, ResourceUri);
            var tokens = new Tokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };
            return tokens;
        }
    }
}
