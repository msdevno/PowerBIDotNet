// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface ITables
    {
        IEnumerable<Table> GetFor(Group group, Dataset dataset);
        IEnumerable<Table> GetFor(Dataset dataset);

        TableSchema GetTableSchemaFor<T>();
        TableSchema GetTableSchemaFor<T>(string tableName);

        void UpdateSchema<T>(Dataset dataset);
        void UpdateSchema<T>(Dataset dataset, string tableName);
        
    }
}
