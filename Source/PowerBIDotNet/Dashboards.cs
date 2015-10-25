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
