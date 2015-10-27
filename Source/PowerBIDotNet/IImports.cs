// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality to work with <see cref="Import"/>
    /// </summary>
    public interface IImports
    {
        /// <summary>
        /// Get all <see cref="Import">imports</see> in the <see cref="IWorkspace"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<Import> GetAll();

        /// <summary>
        /// Import a specific file into the <see cref="IWorkspace"/>
        /// </summary>
        /// <param name="file">Path of the file to import</param>
        void Import(string file);
    }
}
