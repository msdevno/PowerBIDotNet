// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    public class DatasetCreate
    {
        public string Name { get; set; }

        public TableSchema[] Tables { get; set; }
    }
}
