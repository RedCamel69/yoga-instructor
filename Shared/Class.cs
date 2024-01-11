using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    public class Class
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Location { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;

        public TimeOnly StartTime {  get; set; }

        public TimeOnly EndTime { get; set; }

        public bool DisplayOnLandingPage { get; set; } = true;

        public bool WeeklyRecurring { get; set; } = true;       

        public bool Active { get; set; } = true;

        public string? SpecialNotes { get; set; } = null;

        public Class(string id, string name, string location, DateTime date, decimal price)
            => (Id, Name, Location, Date, Price) = (id, name, location, date, price);

        public Class() { }
    }
}
