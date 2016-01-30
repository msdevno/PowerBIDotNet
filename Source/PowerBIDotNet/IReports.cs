// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the functionality to work with <see cref="Report"/>
    /// </summary>
    public interface IReports
    {
        /// <summary>
        /// Get all <see cref="Report">reports</see> for a group in the <see cref="IWorkspace"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<Report> GetAll();



        /// <summary>
        /// Get all <see cref="Report">reports</see> for a group in the <see cref="IWorkspace"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<Report> GetFor(Group group);
    }
}
