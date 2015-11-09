// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet.Wrappers
{
    /// <summary>
    /// Represents a wrapper for working with rows for the API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RowsWrapper<T>
    {
        /// <summary>
        /// Gets or sets the rows
        /// </summary>
        public T[] Rows { get; set; }
    }
}
