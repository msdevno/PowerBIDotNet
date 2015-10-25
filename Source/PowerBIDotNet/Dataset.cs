namespace PowerBIDotNet
{
    public class Dataset
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Table[] Tables { get; set; }
    }
}