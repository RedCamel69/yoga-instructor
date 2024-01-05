using MongoDB.Driver;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ClassService : IClassService
    {
        public ServiceResponse<List<Class>> GetClasses()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Class>>> GetClassesAsync()
        {
            var response = new ServiceResponse<List<Class>>();
            try
            {
                var client = new MongoClient("mongodb://mybreathingspace:jvuhqbxKyUbvOOJdsvGT4f5KiFLGcqvcPuL0jAVHzRaEoZTvgKDZHCAgOGoQJHKyBwAbXsclBmEWACDbFa2iaw==@mybreathingspace.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@mybreathingspace@");
                var db = client.GetDatabase("mybreathingspace");

                var classes = db.GetCollection<Class>("class");

                var classesList = new List<Class>();
                classesList = await classes.FindAsync(x => x.Id != null).Result.ToListAsync();

                foreach (var c in classesList)
                {
                    response.Data.Add(c);
                }

                //response.Data = await _context.Courses
                //    .Include(x => x.Language)
                //    .Include(t => t.Tutor)
                //    .ToListAsync();
                response.Success = true;
                response.Message = "Courses successfully retrieved";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = "Courses could not be retrieved : " + ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
