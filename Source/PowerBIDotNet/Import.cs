namespace Infrastructure.PowerBI
{
    public class Import
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Report[] Reports { get; set; }
        public Dataset[] Datasets { get; set; }
    }
}