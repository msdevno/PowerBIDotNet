namespace Infrastructure.PowerBI
{
    public class TenantConfiguration
    {
        public TenantConfiguration()
        {
            Tenant = "[Not Set]";
            Client = "[Not Set]";
            AuthorizationToken = "[Not Set]";
            RefreshToken = "[Not Set]";
        }

        public Tenant Tenant { get; set; }

        public Client Client { get; set; }

        public ClientSecret ClientSecret { get; set; }

        public Token AuthorizationToken { get; set; }

        public Token RefreshToken { get; set; }

        public string Dataset { get; set; }
        public string Table { get; set; }
    }
}
