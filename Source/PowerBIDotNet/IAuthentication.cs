namespace PowerBIDotNet
{
    public interface IAuthentication
    {
        Tokens GetTokens(Client client);
        Tokens GetTokens(Client client, ClientSecret clientSecret, Token token, string redirectUri);

        Tokens RefreshToken(Client client, Token refreshToken);
    }
}
