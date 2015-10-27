// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a report in a <see cref="Import">import</see>
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Gets or sets the Id of the report
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the report
        /// </summary>
        public string Name { get; set; }
    }
}