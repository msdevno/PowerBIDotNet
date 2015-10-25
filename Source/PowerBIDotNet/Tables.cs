using System;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Tables : ITables
    {
        TenantConfiguration _tenantConfiguration;
        ICommunication _communication;

        public Tables(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _tenantConfiguration = tenantConfiguration;
            _communication = communication;
        }
        public IEnumerable<Table> GetFor(Group group, Dataset dataset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetFor(Dataset dataset)
        {
            try {
                var tables = _communication.Get<TablesWrapper>(_tenantConfiguration, $"datasets/{dataset.Id}/tables");
                return tables.Value;
            } catch
            {
                return new Table[0];
            }
        }

        public void UpdateSchema<T>(Dataset dataset)
        {
            UpdateSchema<T>(dataset, typeof(T).Name);
        }

        public void UpdateSchema<T>(Dataset dataset, string tableName)
        {
            var schema = GetTableSchemaFor<T>(tableName);
            _communication.Put(_tenantConfiguration, $"datasets/{dataset.Id}/tables/{tableName}", schema);
        }

        TableSchema GetTableSchema(Type type, string tableName)
        {
            var schema = new TableSchema { Name = tableName };

            var columns = new List<Column>();


            var properties = type.GetProperties();
            var typeName = string.Empty;

            foreach (var p in properties)
            {
                var propertyName = p.PropertyType.Name;
                if (propertyName.StartsWith("Nullable") && 
                    p.PropertyType.GenericTypeArguments != null && 
                    p.PropertyType.GenericTypeArguments.Length == 1)
                    propertyName = p.PropertyType.GenericTypeArguments[0].Name;

                switch (propertyName)
                {
                    case "Int32":
                    case "Int64":
                        typeName = "Int64";
                        break;
                    case "Double":
                        typeName = "Double";
                        break;
                    case "Boolean":
                        typeName = "bool";
                        break;
                    case "DateTime":
                        typeName = "DateTime";
                        break;
                    case "String":
                        typeName = "string";
                        break;
                    default:
                        typeName = null;
                        break;
                }

                if (typeName == null)
                    throw new Exception("type not supported");

                columns.Add(new Column
                {
                    Name = p.Name,
                    DataType = typeName
                });
            }


            schema.Columns = columns.ToArray();

            return schema;
        }

        public TableSchema GetTableSchemaFor<T>()
        {
            return GetTableSchemaFor<T>(typeof(T).Name);
        }

        public TableSchema GetTableSchemaFor<T>(string tableName)
        {
            var schema = GetTableSchema(typeof(T), tableName);
            return schema;
        }
    }
}
