// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines a system for handling authentication
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Get tokens for a specific client
        /// </summary>
        /// <param name="client"><see cref="Client"/> to get tokens for</param>
        /// <returns><see cref="Tokens"/> for the client</returns>
        Tokens GetTokens(Client client);

        /// <summary>
        /// Get tokens for a <see cref="Client"/>based on <see cref="ClientSecret"/>, <see cref="Token"/> and a redirectUri
        /// </summary>
        /// <param name="client"><see cref="Client"/> to get for</param>
        /// <param name="clientSecret"><see cref="ClientSecret"/> to use</param>
        /// <param name="token"><see cref="Token"/>, typically from a reply</param>
        /// <param name="redirectUri">RedirectURI used in initial authentication call</param>
        /// <returns><see cref="Tokens"/> for the client</returns>
        Tokens GetTokens(Client client, ClientSecret clientSecret, Token token, string redirectUri);


        /// <summary>
        /// Refresh a <see cref="Token"/> for a <see cref="Client"/>
        /// </summary>
        /// <param name="client"><see cref="Client"/> to refresh token for</param>
        /// <param name="refreshToken"><see cref="Token">Refresh token</see> to use</param>
        /// <returns><see cref="Tokens"/> for the client</returns>
        Tokens RefreshToken(Client client, Token refreshToken);
    }
}
