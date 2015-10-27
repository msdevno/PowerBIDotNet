// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with rows in a <see cref="Dataset"/> and <see cref="Table"/>
    /// </summary>
    public interface IRows
    {
        /// <summary>
        /// Add a row to a <see cref="Dataset"/>
        /// </summary>
        /// <typeparam name="T">Type of row to add</typeparam>
        /// <param name="dataset"><see cref="Dataset"/> to add to</param>
        /// <param name="row">Row to add</param>
        /// <remarks>
        /// Name of the table is implicitly defined by the name of the type of row
        /// </remarks>
        void Add<T>(Dataset dataset, T row);

        /// <summary>
        /// Add a row to a specific table in a <see cref="Dataset"/> 
        /// </summary>
        /// <typeparam name="T">Type of row to add</typeparam>
        /// <param name="dataset"><see cref="Dataset"/> to add to</param>
        /// <param name="tableName">Name of table to add to</param>
        /// <param name="row">Row to add</param>
        void Add<T>(Dataset dataset, string tableName,  T row);


        /// <summary>
        /// Add a set of rows to a specific table in a <see cref="Dataset"/> 
        /// </summary>
        /// <typeparam name="T">Type of row to add</typeparam>
        /// <param name="dataset"><see cref="Dataset"/> to add to</param>
        /// <param name="tableName">Name of table to add to</param>
        /// <param name="row">Row to add</param>
        void Add<T>(Dataset dataset, string tableName, IEnumerable<T> rows);
    }
}