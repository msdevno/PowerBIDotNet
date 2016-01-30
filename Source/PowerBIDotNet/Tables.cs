// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;
using PowerBIDotNet.Wrappers;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="ITables"/>
    /// </summary>
    public class Tables : ITables
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes a new instance of <see cref="Tables"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Tables(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

#pragma warning disable 1591 // Xml Comments
        public IEnumerable<Table> GetFor(Group group, Dataset dataset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetFor(Dataset dataset)
        {
            try {
                var tables = _communication.Get<TablesWrapper>(_token, $"datasets/{dataset.Id}/tables");
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
            _communication.Put(_token, $"datasets/{dataset.Id}/tables/{tableName}", schema);
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
#pragma warning restore 1591 // Xml Comments

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
    }
}
