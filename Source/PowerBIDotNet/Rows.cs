using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.PowerBI
{
    public class Rows : IRows
    {
        Token _token;
        ICommunication _communication;

        public Rows(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

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
    }
}
