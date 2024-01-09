using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ClassDatabaseSettings : IClassDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClassCollectionName { get; set; } = null!;

        public ClassDatabaseSettings() {

            ConnectionString = Environment.GetEnvironmentVariable("ConnectionStringCosmos"); 
            DatabaseName = Environment.GetEnvironmentVariable("DatabaseName");
            ClassCollectionName = Environment.GetEnvironmentVariable("ClassCollectionName");
        }
    }
}
