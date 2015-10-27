// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="Dataset">datasets</see>
    /// </summary>
    public interface IDatasets
    {
        /// <summary>
        /// Get all available <see cref="Dataset">datasets</see>
        /// </summary>
        /// <returns><see cref="IEnumerable{Dataset}">Datasets</see></returns>
        IEnumerable<Dataset> GetAll();

        /// <summary>
        /// Get all available <see cref="Dataset">datasets</see> for a specific <see cref="Group"/>
        /// </summary>
        /// <param name="group"><see cref="Group"/> to get for</param>
        /// <returns><see cref="IEnumerable{Dataset}">Datasets</see></returns>
        IEnumerable<Dataset> GetFor(Group group);

        /// <summary>
        /// Get <see cref="Dataset"/> by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see cref="Dataset"/> found</returns>
        Dataset GetByName(string name);

        /// <summary>
        /// Create a <see cref="Dataset"/> from one or more <see cref="TableSchema">table schemas</see>
        /// </summary>
        /// <param name="name">Name of the dataset</param>
        /// <param name="tables"><see cref="TableSchema">Table schenas</see> to include in the dataset</param>
        /// <returns>The created <see cref="Dataset"/></returns>
        /// <remarks>
        /// Look at <see cref="ITables"/> for generating <see cref="TableSchema"/> from types
        /// </remarks>
        Dataset Create(string name, params TableSchema[] tables);
    }
}
