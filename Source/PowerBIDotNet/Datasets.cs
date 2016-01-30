// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Linq;
using System.Collections.Generic;
using PowerBIDotNet.Wrappers;
using PowerBIDotNet.Commands;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IDatasets"/>
    /// </summary>
    public class Datasets : IDatasets
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes an instance of <see cref="Datasets"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Datasets(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

#pragma warning disable 1591 // Xml Comments
        public IEnumerable<Dataset> GetAll()
        {
            var datasets = _communication.Get<DatasetsWrapper>(_token, "datasets");
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
            var dataset = _communication.Post<Dataset, DatasetCreate>(_token, $"datasets", new DatasetCreate
            {
                Name = name,
                Tables = tables
            });
            return dataset;
        }
#pragma warning restore 1591 // Xml Comments
    }
}
