using System;
using System.Reflection;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Bifrost.Concepts;
using Microsoft.WindowsAzure.Storage;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class ConfigurationForTenants : IConfigurationForTenants
    {
        const string TableName = "TenantsConfiguration";

        static PropertyInfo[] _properties = typeof(TenantConfiguration).GetProperties();
        StorageConfiguration _storageConfiguration;

        CloudTable _table;


        public ConfigurationForTenants(StorageConfiguration storageConfiguration)
        {
            _storageConfiguration = storageConfiguration;
            SetupTable();
        }

        void SetupTable()
        {
            var connectionString = $"DefaultEndpointsProtocol=https;AccountName={_storageConfiguration.AccountName};AccountKey={_storageConfiguration.AccessKey}";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();

            _table = tableClient.GetTableReference(TableName);
            _table.CreateIfNotExists();
        }



        public TenantConfiguration GetFor(Tenant tenant)
        {
            var query = _table.CreateQuery<DynamicTableEntity>()
                .Where(e =>
                    e.PartitionKey == tenant &&
                    e.RowKey == tenant);

            var result = query.FirstOrDefault();
            if (result != null) return Map(result);

            return null;
        }

        public void Save(TenantConfiguration configuration)
        {
            var entity = new DynamicTableEntity(configuration.Tenant, configuration.Tenant);

            foreach( var property in _properties )
            {
                var value = property.GetValue(configuration);
                var valueAsString = string.Empty;
                if (value != null)
                {
                    if (property.PropertyType.IsConcept()) value = value.GetConceptValue();

                    valueAsString = value.ToString();
                }
                
                entity.Properties.Add(property.Name, new EntityProperty(valueAsString));
            }

            var operation = TableOperation.InsertOrReplace(entity);
            _table.Execute(operation);
        }

        public IEnumerable<TenantConfiguration> GetAll()
        {
            var all = _table.CreateQuery<DynamicTableEntity>().Select(Map).ToArray();
            return all;
        }


        TenantConfiguration Map(DynamicTableEntity entity)
        {
            var configuration = new TenantConfiguration();
            foreach (var property in _properties )
            {
                if (entity.Properties.ContainsKey(property.Name))
                {
                    var targetType = property.PropertyType;
                    var value = entity.Properties[property.Name].StringValue;

                    if (targetType.IsConcept())
                        property.SetValue(configuration, ConceptFactory.CreateConceptInstance(targetType, value));
                    else
                        property.SetValue(configuration, Convert.ChangeType(value, targetType));
                }
            }
            return configuration;
        }
    }
}
