using System.Collections.Generic;
using System.Linq;
using PowerBIDotNet;
using Microsoft.AspNet.SignalR;

namespace Web.Simulator
{
    public class SimulatorHub : Hub
    {
        IConfigurationForTenants _configurationForTenants;

        public SimulatorHub(IConfigurationForTenants configurationForTenants)
        {
            _configurationForTenants = configurationForTenants;
        }

        public IEnumerable<dynamic>   GetAllTenants()
        {
            var configurations = _configurationForTenants.GetAll();
            return Map(configurations);
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
