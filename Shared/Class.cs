namespace Shared
{
    public class Class
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }

        public Class(string id, string name, string location, string date)
            => (Id, Name, Location, Date) = (id, name, location, date);
    }
}
