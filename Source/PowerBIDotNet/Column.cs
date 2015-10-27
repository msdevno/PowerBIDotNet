// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a column in a <see cref="Table"/>, typically used in a <see cref="TableSchema"/>
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the name of the column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the datatype for the column
        /// </summary>
        public string DataType { get; set; }
    }
}
