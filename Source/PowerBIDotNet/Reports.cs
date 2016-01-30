// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;
using PowerBIDotNet.Wrappers;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IReports"/>
    /// </summary>
    public class Reports : IReports
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes a new instance of <see cref="Reports"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Reports(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

#pragma warning disable 1591 // Xml Comments
        public IEnumerable<Report> GetAll()
        {
            try
            {
                var reports = _communication.Get<ReportsWrapper>(_token, $"reports", "beta");
                return reports.Value;
            }
            catch
            {
                return new Report[0];
            }
        }


        public IEnumerable<Report> GetFor(Group group)
        {
            try {
                var reports = _communication.Get<ReportsWrapper>(_token, $"beta/myorg/groups/{group.Id}/reports");
                return reports.Value;
            } catch
            {
                return new Report[0];
            }
        }
#pragma warning restore 1591 // Xml Comments
    }
}
