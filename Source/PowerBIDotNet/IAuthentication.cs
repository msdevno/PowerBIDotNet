// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    public interface IAuthentication
    {
        Tokens GetTokens(Client client);
        Tokens GetTokens(Client client, ClientSecret clientSecret, Token token, string redirectUri);

        Tokens RefreshToken(Client client, Token refreshToken);
    }
}
