namespace PowerBIDotNet
{
    public class TenantConfiguration
    {
        public TenantConfiguration()
        {
            Tenant = "[Not Set]";
            Client = "[Not Set]";
            AccessToken = "[Not Set]";
            RefreshToken = "[Not Set]";
        }

        public Tenant Tenant { get; set; }

        public Client Client { get; set; }

        public ClientSecret ClientSecret { get; set; }

        public Token AccessToken { get; set; }

        public Token RefreshToken { get; set; }

        public string Dataset { get; set; }
        public string Table { get; set; }
    }
}
