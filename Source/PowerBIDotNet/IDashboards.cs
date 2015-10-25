using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface IDashboards
    {
        IEnumerable<Dashboard> GetFor(Group group);
    }
}
