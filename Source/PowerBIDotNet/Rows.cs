using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.PowerBI
{
    public class Rows : IRows
    {
        TenantConfiguration _tenantConfiguration;
        ICommunication _communication;

        public Rows(TenantConfiguration tenantConfiguration, ICommunication communication)
        {
            _tenantConfiguration = tenantConfiguration;
            _communication = communication;
        }

        public void Add<T>(Dataset dataset, T row)
        {
            Add(dataset, typeof(T).Name, row);
        }

        public void Add<T>(Dataset dataset, string tableName, T row)
        {
            var action = $"datasets/{dataset.Id}/tables/{tableName}/rows";
            _communication.Post(_tenantConfiguration, action, new RowsWrapper<T> { Rows = new[] { row } });
        }

        public void Add<T>(Dataset dataset, string tableName, IEnumerable<T> rows)
        {
            var action = $"datasets/{dataset.Id}/tables/{tableName}/rows";
            _communication.Post(_tenantConfiguration, action, new RowsWrapper<T> { Rows = rows.ToArray() });
        }
    }
}
