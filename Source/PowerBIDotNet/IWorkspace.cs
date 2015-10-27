// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

// https://msdn.microsoft.com/en-us/library/mt243840.aspx

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for a workspace
    /// </summary>
    public interface IWorkspace
    {
        /// <summary>
        /// Gets the <see cref="IImports"/> functionality
        /// </summary>
        IImports Imports { get; }

        /// <summary>
        /// Gets the <see cref="IGroups"/> functionality
        /// </summary>
        IGroups Groups { get; }

        /// <summary>
        /// Gets the <see cref="IRows"/> functionality
        /// </summary>
        IRows Rows { get; }

        /// <summary>
        /// Gets the <see cref="IDatasets"/> functionality
        /// </summary>
        IDatasets Datasets { get;  }

        /// <summary>
        /// Gets the <see cref="ITables"/> functionality
        /// </summary>
        ITables Tables { get; }
    }
}
