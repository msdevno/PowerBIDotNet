// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="Dashboard">dashboards</see>
    /// </summary>
    public interface IDashboards
    {
        /// <summary>
        /// Get all dashboards for a given group
        /// </summary>
        /// <returns>All <see cref="Dashboard">dashboards</see></returns>
        IEnumerable<Dashboard> GetAll();
    }
}
