// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines a system for holding configuration for <see cref="Tenant">tenants</see>
    /// </summary>
    public interface IConfigurationForTenants
    {
        /// <summary>
        /// Get all configuration elements for all <see cref="Tenant">tenants</see>
        /// </summary>
        /// <returns></returns>
        IEnumerable<TenantConfiguration> GetAll();

        /// <summary>
        /// Get configuration for a specific <see cref="Tenant"/>
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        TenantConfiguration GetFor(Tenant tenant);

        /// <summary>
        /// Save a configuration for a <see cref="Tenant"/>
        /// </summary>
        /// <param name="configuration"></param>
        void Save(TenantConfiguration configuration);
    }
}
