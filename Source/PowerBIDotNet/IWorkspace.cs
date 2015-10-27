// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

// https://msdn.microsoft.com/en-us/library/mt243840.aspx

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IWorkspace
    {
        IImports Imports { get; }

        IGroups Groups { get; }

        IRows Rows { get; }

        IDatasets Datasets { get;  }

        ITables Tables { get; }
    }
}
