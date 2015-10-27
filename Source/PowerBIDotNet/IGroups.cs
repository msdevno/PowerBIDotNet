// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality for working with <see cref="Group">groups</see>
    /// </summary>
    public interface IGroups
    {
        /// <summary>
        /// Get all <see cref="Group">groups</see> in <see cref="IWorkspace"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{Group}">Groups</see> in the <see cref="IWorkspace"/></returns>
        IEnumerable<Group> GetAll();
    }
}
