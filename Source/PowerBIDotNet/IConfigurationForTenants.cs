using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IConfigurationForTenants
    {
        IEnumerable<TenantConfiguration> GetAll();

        TenantConfiguration GetFor(Tenant tenant);

        void Save(TenantConfiguration configuration);
    }
}
