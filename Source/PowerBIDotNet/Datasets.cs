using System;
using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Datasets : IDatasets
    {
        TenantConfiguration _tenantConfiguration;
        ICommunication _communication;

        public Datasets(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _tenantConfiguration = tenantConfiguration;
            _communication = communication;
        }

        public IEnumerable<Dataset> GetAll()
        {
            var datasets = _communication.Get<DatasetsWrapper>(_tenantConfiguration, "datasets");
            return datasets.Value;
        }

        public IEnumerable<Dataset> GetFor(Group group)
        {
            throw new NotImplementedException();
        }

        public Dataset GetByName(string name)
        {
            var dataset = GetAll().Where(d => d.Name == name).SingleOrDefault();
            return dataset;
        }

        public Dataset Create(string name, params TableSchema[] tables)
        {
            var dataset = _communication.Post<Dataset, DatasetCreate>(_tenantConfiguration, $"datasets", new DatasetCreate
            {
                Name = name,
                Tables = tables
            });
            return dataset;
        }
    }
}
