// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IConfigurationForTenants
    {
        IEnumerable<TenantConfiguration> GetAll();

        TenantConfiguration GetFor(Tenant tenant);

        void Save(TenantConfiguration configuration);
    }
}
