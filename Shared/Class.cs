using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Linq;

namespace SharedModels
{
    public class Class
    {

        private TimeOnly _endTime;
        private string _displayEndTime;
        private TimeOnly _startTime;
        private string _displayStartTime;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Location { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;

        public TimeOnly StartTime {
            get { return _startTime; }
            set { _startTime = value;
                if (value.Hour > 12)
                {
                    var hour = value.Hour - 12;
                    _displayStartTime = hour.ToString() + " PM";
                }
                else
                {
                    _displayStartTime = value.Hour.ToString() + " AM";
                }
            } 
        }

        
        public TimeOnly EndTime
        {
            get { return _endTime; }   
            set { 
                _endTime = value; 
                if (value.Hour > 12)
                {
                    var hour = value.Hour - 12;
                    _displayEndTime = hour.ToString() + " PM";
                }
                else
                {
                    _displayEndTime = value.Hour.ToString() + " AM";
                }
            }  
        }

        public string? DisplayStartTime { 
            get { return _displayStartTime; }
            set { _displayStartTime = value; }
        } 
        public string? DisplayEndTime {
                get { return _displayEndTime; }
                set { _displayEndTime = value; }
            }

        public bool DisplayOnLandingPage { get; set; } = true;

        public bool WeeklyRecurring { get; set; } = true;       

        public bool Active { get; set; } = true;

        public string? SpecialNotes { get; set; } = null;

        public Class(string id, string name, string location, DateTime date, decimal price)
            => (Id, Name, Location, Date, Price) = (id, name, location, date, price);

        public Class() { }
    }
}
