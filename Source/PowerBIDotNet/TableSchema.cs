// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 


namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the schema for a <see cref="Table"/>
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="Table"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Column">columns</see>
        /// </summary>
        public Column[] Columns { get; set; }
    }
}
