using System;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Workspace : IWorkspace
    {
        ICommunication _communication;

        public Workspace(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _communication = communication;

            Groups = new Groups(tenantConfiguration, communication);
            Datasets = new Datasets(tenantConfiguration, communication);
            Tables = new Tables(tenantConfiguration, communication);
            Rows = new Rows(tenantConfiguration, communication);
            Dashboards = new Dashboards(tenantConfiguration, communication);
        }

        public IGroups Groups { get; private set; }

        public IDatasets Datasets { get; private set; }

        public ITables Tables { get; private set; }

        public IRows Rows { get; private set; }

        public IDashboards Dashboards { get; private set; }

        public IImports Imports { get; private set; }
    }
}
