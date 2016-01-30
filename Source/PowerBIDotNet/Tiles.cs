// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;
using PowerBIDotNet.Wrappers;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="ITiles"/>
    /// </summary>
    public class Tiles : ITiles
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes a new instance of <see cref="Tiles"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Tiles(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }


#pragma warning disable 1591 // Xml Comments
        public IEnumerable<Tile> GetFor(Dashboard dashboard)
        {
            try
            {
                var tiles = _communication.Get<TilesWrapper>(_token, $"dashboards/{dashboard.Id}/tiles", "beta");
                return tiles.Value;
            }
            catch
            {
                return new Tile[0];
            }

        }

#pragma warning restore 1591 // Xml Comments
    }
}
