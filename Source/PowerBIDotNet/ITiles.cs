// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="Tile">tiles</see> in a <see cref="Dashboard"/>
    /// </summary>
    public interface ITiles
    {
        /// <summary>
        /// Get tiles for a <see cref="Dashboard"/>
        /// </summary>
        /// <param name="dashboard"><see cref="Dashboard"/> to get <see cref="Tile">tiles</see> for</param>
        /// <returns></returns>
        IEnumerable<Tile> GetFor(Dashboard dashboard);
    }
}
