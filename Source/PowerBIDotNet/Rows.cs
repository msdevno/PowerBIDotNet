// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;
using System.Linq;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IRows"/>
    /// </summary>
    public class Rows : IRows
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes an instance of <see cref="Rows"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Rows(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

#pragma warning disable 1591 // Xml Comments
        public void Add<T>(Dataset dataset, T row)
        {
            Add(dataset, typeof(T).Name, row);
        }

        public void Add<T>(Dataset dataset, string tableName, T row)
        {
            var action = $"datasets/{dataset.Id}/tables/{tableName}/rows";
            _communication.Post(_token, action, new RowsWrapper<T> { Rows = new[] { row } });
        }

        public void Add<T>(Dataset dataset, string tableName, IEnumerable<T> rows)
        {
            var action = $"datasets/{dataset.Id}/tables/{tableName}/rows";
            _communication.Post(_token, action, new RowsWrapper<T> { Rows = rows.ToArray() });
        }
#pragma warning restore 1591 // Xml Comments
    }
}
