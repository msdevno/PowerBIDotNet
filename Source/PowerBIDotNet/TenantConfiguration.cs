// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the configuration for a <see cref="Tenant">tenant</see> with regards to authentication
    /// </summary>
    public class TenantConfiguration
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TenantConfiguration"/>
        /// </summary>
        public TenantConfiguration()
        {
            Tenant = "[Not Set]";
            Client = "[Not Set]";
            AccessToken = "[Not Set]";
            RefreshToken = "[Not Set]";
        }

        /// <summary>
        /// Gets or sets the <see cref="Tenant"/>
        /// </summary>
        public Tenant Tenant { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Client"/>
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ClientSecret"/>
        /// </summary>
        public ClientSecret ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Token">access token</see>
        /// </summary>
        public Token AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Token">refreh token</see>
        /// </summary>
        public Token RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Dataset"/>
        /// </summary>
        public string Dataset { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Table"/>
        /// </summary>
        public string Table { get; set; }
    }
}
