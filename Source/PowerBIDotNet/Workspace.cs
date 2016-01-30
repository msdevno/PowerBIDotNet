// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IWorkspace"/>
    /// </summary>
    public class Workspace : IWorkspace
    {
        ICommunication _communication;

        /// <summary>
        /// Initializes a new instance of <see cref="Workspace"/> for a given <see cref="Token"/> with a given <see cref="ICommunication"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token to use</see></param>
        /// <param name="communication"><see cref="ICommunication"/> to use</param>
        public Workspace(Token token, ICommunication communication)
        {
            _communication = communication;

            Groups = new Groups(token, communication);
            Datasets = new Datasets(token, communication);
            Tables = new Tables(token, communication);
            Rows = new Rows(token, communication);
            Dashboards = new Dashboards(token, communication);
            Reports = new Reports(token, communication);
            Tiles = new Tiles(token, communication);
        }

#pragma warning disable 1591 // Xml Comments
        public IGroups Groups { get; private set; }

        public IDatasets Datasets { get; private set; }

        public ITables Tables { get; private set; }

        public IRows Rows { get; private set; }

        public IDashboards Dashboards { get; private set; }

        public IReports Reports { get; private set; }

        public IImports Imports { get; private set; }

        public ITiles Tiles { get; private set; }

#pragma warning restore 1591 // Xml Comments

        /// <summary>
        /// Get a <see cref="IWorkspace"/> for a specific <see cref="Token"/>
        /// </summary>
        /// <param name="accessToken"><see cref="Token">Access token</see> to get <see cref="IWorkspace">workspace</see> for</param>
        /// <returns>A new instance of a <see cref="IWorkspace">workspace</see> for the given token</returns>
        public static IWorkspace GetFor(Token accessToken)
        {
            var workspace = new Workspace(accessToken, new Communication(new WebRequestFactory()));
            return workspace;
        }
    }
}
