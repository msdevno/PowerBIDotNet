// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="IWorkspace">workspaces</see> for <see cref="Tenant">tenants</see>
    /// </summary>
    public interface IWorkspaces
    {
        /// <summary>
        /// Get a <see cref="IWorkspace"/> for a specific <see cref="Tenant"/>
        /// </summary>
        /// <param name="tenant"><see cref="Tenant"/> to get for </param>
        /// <returns><see cref="IWorkspace"/> for the tenant</returns>
        IWorkspace GetFor(Tenant tenant);
    }
}
