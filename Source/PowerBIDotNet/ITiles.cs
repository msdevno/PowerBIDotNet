using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface ITiles
    {
        IEnumerable<Tile> GetFor(Dashboard dashboard);
    }
}
