using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IDashboards
    {
        IEnumerable<Dashboard> GetFor(Group group);
    }
}
