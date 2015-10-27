// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an import
    /// </summary>
    public class Import
    {
        /// <summary>
        /// Gets or sets the Id of the import
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the import
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path of the file for the import
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the reports in the import
        /// </summary>
        public Report[] Reports { get; set; }

        /// <summary>
        /// Gets or sets the datasets of the import
        /// </summary>
        public Dataset[] Datasets { get; set; }
    }
}