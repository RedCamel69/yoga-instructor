using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared
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

        public string Date { get; set; } = null!;
        public Class(string id, string name, string location, string date, decimal price)
            => (Id, Name, Location, Date, Price) = (id, name, location, date, price);
    }
}
