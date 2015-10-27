// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;

namespace PowerBIDotNet
{
    public class Dashboards : IDashboards
    {
        Token _token;
        ICommunication _communication;
  
        public Dashboards(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

        public IEnumerable<Dashboard> GetFor(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
