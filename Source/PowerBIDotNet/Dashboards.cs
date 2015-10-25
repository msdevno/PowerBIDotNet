using System;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Dashboards : IDashboards
    {
        TenantConfiguration _tenantConfiguration;
        ICommunication _communication;
  
        public Dashboards(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _tenantConfiguration = tenantConfiguration;
            _communication = communication;
        }

        public IEnumerable<Dashboard> GetFor(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
