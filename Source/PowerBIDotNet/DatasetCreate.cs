namespace Infrastructure.PowerBI
{
    public class DatasetCreate
    {
        public string Name { get; set; }

        public TableSchema[] Tables { get; set; }
    }
}
