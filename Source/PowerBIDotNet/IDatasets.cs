// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IDatasets
    {
        IEnumerable<Dataset> GetAll();
        IEnumerable<Dataset> GetFor(Group group);
        Dataset GetByName(string v);

        Dataset Create(string name, params TableSchema[] tables);
    }
}
