// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents a tile in a <see cref="Dashboard"/>
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Gets or sets the Id of the tile
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the tile
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL that represent the embeddable version of the tile
        /// </summary>
        public string EmbedUrl { get; set; }
    }
}
