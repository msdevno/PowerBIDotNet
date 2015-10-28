// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IWorkspaces"/>
    /// </summary>
    public class Workspaces : IWorkspaces
    {
        ICommunication _communication;
        IConfigurationForTenants _configurationForTenants;

        /// <summary>
        /// Initializes a new instance of <see cref="Workspaces"/>
        /// </summary>
        /// <param name="communication"><see cref="ICommunication"/> to use</param>
        /// <param name="configurationForTenants"><see cref="IConfigurationForTenants"/> to use</param>
        public Workspaces(ICommunication communication, IConfigurationForTenants configurationForTenants)
        {
            _communication = communication;
            _configurationForTenants = configurationForTenants;
        }

#pragma warning disable 1591 // Xml Comments
        public IWorkspace GetFor(Tenant tenant)
        {
            var tenantConfiguration = _configurationForTenants.GetFor(tenant);
            var workspace = new Workspace(tenantConfiguration.AccessToken, _communication);
            return workspace;
        }
#pragma warning restore 1591 // Xml Comments
    }
}
