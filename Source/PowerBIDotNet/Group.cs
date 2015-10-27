// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a group in a <see cref="IWorkspace"/>
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the Id of the group
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the group
        /// </summary>
        public string Name { get; set; }
    }
}