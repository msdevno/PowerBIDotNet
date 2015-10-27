// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the operation of creating a <see cref="Dataset"/>
    /// </summary>
    public class DatasetCreate
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="Dataset"/> to create
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="TableSchema">table schemas</see>
        /// </summary>
        public TableSchema[] Tables { get; set; }
    }
}
