using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IRows
    {
        void Add<T>(Dataset dataset, T row);
        void Add<T>(Dataset dataset, string tableName,  T row);

        void Add<T>(Dataset dataset, string tableName, IEnumerable<T> rows);
    }
}