using System;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Groups : IGroups
    {
        TenantConfiguration _tenantConfiguration;
        ICommunication _communication;

        public Groups(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _tenantConfiguration = tenantConfiguration;
            _communication = communication;
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = _communication.Get<GroupsWrapper>(_tenantConfiguration, "groups");
            return groups.Value;
        }
    }
}
