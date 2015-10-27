// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    public class Dataset
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Table[] Tables { get; set; }
    }
}