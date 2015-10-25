using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IGroups
    {
        IEnumerable<Group> GetAll();
    }
}
