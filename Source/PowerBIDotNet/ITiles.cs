using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface ITiles
    {
        IEnumerable<Tile> GetFor(Dashboard dashboard);
    }
}
