// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IRows
    {
        void Add<T>(Dataset dataset, T row);
        void Add<T>(Dataset dataset, string tableName,  T row);

        void Add<T>(Dataset dataset, string tableName, IEnumerable<T> rows);
    }
}