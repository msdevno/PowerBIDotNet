// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a dataset in a <see cref="IWorksapce"/>
    /// </summary>
    public class Dataset
    {
        /// <summary>
        /// Gets or sets the Id of the dataset
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the dataset
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets all <see cref="Table">tables</see> in the <see cref="Dataset"/>
        /// </summary>
        public Table[] Tables { get; set; }
    }
}