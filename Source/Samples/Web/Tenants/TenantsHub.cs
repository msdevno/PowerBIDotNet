using System.Collections.Generic;
using System.Linq;
using Infrastructure.PowerBI;
using Microsoft.AspNet.SignalR;

namespace Web.Tenants
{
    public class TenantsHub : Hub
    {
        IConfigurationForTenants _configurationForTenants;

        public TenantsHub(IConfigurationForTenants configurationForTenants)
        {
            _configurationForTenants = configurationForTenants;
        }

        public IEnumerable<dynamic>   GetAll()
        {
            var configurations = _configurationForTenants.GetAll();
            return Map(configurations);
        }

        public void Save(TenantConfiguration tenantConfiguration)
        {
            if (string.IsNullOrEmpty(tenantConfiguration.AuthorizationToken))
                tenantConfiguration.AuthorizationToken = "[Not Set]";

            if (string.IsNullOrEmpty(tenantConfiguration.RefreshToken))
                tenantConfiguration.RefreshToken = "[Not Set]";

            _configurationForTenants.Save(tenantConfiguration);

            Clients.All.tenantSaved(tenantConfiguration);
        }

        public dynamic Get(Tenant tenant)
        {
            var configuration = _configurationForTenants.GetFor(tenant);
            return Map(configuration);
        }

        IEnumerable<dynamic> Map(IEnumerable<TenantConfiguration> configurations)
        {
            return configurations.Select(c => Map(c));
        }

        dynamic Map(TenantConfiguration configuration)
        {
            return new
            {
                Tenant = configuration.Tenant,
                Client = configuration.Client,
                ClientSecret = configuration.ClientSecret
            };
        }
    }
}
