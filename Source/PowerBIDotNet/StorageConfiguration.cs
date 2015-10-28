// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Holds the configuration for connecting with Azure Storage
    /// </summary>
    public class StorageConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the account
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the access key
        /// </summary>
        public string AccessKey { get; set;  }
    }
}
