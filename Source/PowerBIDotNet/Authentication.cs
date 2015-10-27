// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IAuthentication"/>
    /// </summary>
    public class Authentication : IAuthentication
    {
        // https://auth0.com/docs/connections/enterprise/azure-active-directory

        const string AuthorityUri = "https://login.windows.net/common/oauth2/authorize";
        const string RedirectUri = "https://login.live.com/oauth20_desktop.srf";
        const string ResourceUri = "https://analysis.windows.net/powerbi/api";

#pragma warning disable 1591 // Xml Comments
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
#pragma warning restore 1591 // Xml Comments
    }
}
