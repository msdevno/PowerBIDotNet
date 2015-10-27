// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IImports
    {
        IEnumerable<Import> GetAll();
        void Import(string file);
    }
}
