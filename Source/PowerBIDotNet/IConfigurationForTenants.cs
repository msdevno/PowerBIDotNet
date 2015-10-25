using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface IConfigurationForTenants
    {
        IEnumerable<TenantConfiguration> GetAll();

        TenantConfiguration GetFor(Tenant tenant);

        void Save(TenantConfiguration configuration);
    }
}
