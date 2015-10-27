// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a dashboard in a <see cref="IWorkspace"/>
    /// </summary>
    public class Dashboard
    {
        /// <summary>
        /// Gets or sets the Id of the dashboard
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the dashboard
        /// </summary>
        public string DisplayName { get; set; }
    }
}