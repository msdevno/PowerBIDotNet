namespace PowerBIDotNet
{
    public interface IAuthentication
    {
        void AuthenticateFor(Tenant tenant);

        void RefreshTokenFor(Tenant tenant);
    }
}
