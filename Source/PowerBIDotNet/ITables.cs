using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface ITables
    {
        IEnumerable<Table> GetFor(Group group, Dataset dataset);
        IEnumerable<Table> GetFor(Dataset dataset);

        TableSchema GetTableSchemaFor<T>();
        TableSchema GetTableSchemaFor<T>(string tableName);

        void UpdateSchema<T>(Dataset dataset);
        void UpdateSchema<T>(Dataset dataset, string tableName);
        
    }
}
