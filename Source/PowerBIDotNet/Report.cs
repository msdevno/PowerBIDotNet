// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a report in a <see cref="Report">report</see>
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

        /// <summary>
        /// Gets or sets the URL that can be used to navigate directly to a <see cref="Report"/>
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL that can be used for embedding the <see cref="Report"/> into your own application
        /// </summary>
        public string EmbedUrl { get; set; }
    }
}