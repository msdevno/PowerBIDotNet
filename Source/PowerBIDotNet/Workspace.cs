// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    public class Workspace : IWorkspace
    {
        ICommunication _communication;

        public Workspace(Token token, ICommunication communication)
        {
            _communication = communication;

            Groups = new Groups(token, communication);
            Datasets = new Datasets(token, communication);
            Tables = new Tables(token, communication);
            Rows = new Rows(token, communication);
            Dashboards = new Dashboards(token, communication);
        }

#pragma warning disable 1591 // Xml Comments
        public IGroups Groups { get; private set; }

        public IDatasets Datasets { get; private set; }

        public ITables Tables { get; private set; }

        public IRows Rows { get; private set; }

        public IDashboards Dashboards { get; private set; }

        public IImports Imports { get; private set; }

#pragma warning restore 1591 // Xml Comments

        public static IWorkspace GetFor(Token accessToken)
        {
            var workspace = new Workspace(accessToken, new Communication());
            return workspace;
        }
    }
}
