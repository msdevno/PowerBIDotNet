// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="Table">tables</see>
    /// </summary>
    public interface ITables
    {
        /// <summary>
        /// Get tables for a specific <see cref="Group"/> in a <see cref="Dataset"/>
        /// </summary>
        /// <param name="group"><see cref="Group"/> to get for</param>
        /// <param name="dataset"><see cref="Dataset"/> to get for</param>
        /// <returns><see cref="IEnumerable{Table}">Tables</see> in the <see cref="Group"/> and <see cref="Dataset"/></returns>
        IEnumerable<Table> GetFor(Group group, Dataset dataset);

        /// <summary>
        /// Get tables for a specific <see cref="Dataset"/>
        /// </summary>
        /// <param name="dataset"><see cref="Dataset"/> to get for</param>
        /// <returns><see cref="IEnumerable{Table}">Tables</see> in the <see cref="Dataset"/></returns>
        IEnumerable<Table> GetFor(Dataset dataset);

        /// <summary>
        /// Get <see cref="TableSchema"/> for a type
        /// </summary>
        /// <typeparam name="T">Type to get <see cref="TableSchema">schema</see> for</typeparam>
        /// <returns><see cref="TableSchema"/> with all the details about the table and columns</returns>
        /// <remarks>
        /// It will use the type name as the name of the table
        /// </remarks>
        TableSchema GetTableSchemaFor<T>();

        /// <summary>
        /// Get <see cref="TableSchema"/> for a type with a specified name for the table
        /// </summary>
        /// <typeparam name="T">Type to get <see cref="TableSchema">schema</see> for</typeparam>
        /// <param name="tableName">Name of the table</param>
        /// <returns><see cref="TableSchema"/> with all the details about the table and columns</returns>
        TableSchema GetTableSchemaFor<T>(string tableName);

        /// <summary>
        /// Update schema for a <see cref="Dataset">dataset</see> based on type
        /// </summary>
        /// <typeparam name="T">Type used for the schame update</typeparam>
        /// <param name="dataset"><see cref="Dataset"/> to update</param>
        /// <remarks>
        /// It will use the type name as the name of the table
        /// </remarks>
        void UpdateSchema<T>(Dataset dataset);

        /// <summary>
        /// Update schema for a <see cref="Dataset">dataset</see> based on type with a specified name for the table
        /// </summary>
        /// <typeparam name="T">Type used for the schame update</typeparam>
        /// <param name="dataset"><see cref="Dataset"/> to update</param>
        /// <param name="tableName">Name of the table to update for</param>
        void UpdateSchema<T>(Dataset dataset, string tableName);
    }
}
