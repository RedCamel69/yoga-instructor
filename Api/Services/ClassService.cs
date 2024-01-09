using Api.Data;
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
        private readonly IMongoCollection<Class> _classCollection;

        public ClassService(IClassDatabaseSettings settings) {
            var mongoClient = new MongoClient(settings.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.DatabaseName);

            _classCollection = mongoDatabase.GetCollection<Class>(
                settings.ClassCollectionName);
        }

        public Task<ServiceResponse<Class>> CreateCourseAsync(Class course)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Class>>> GetAsync()
        {

            var test = _classCollection.Find(x => x.Id != null).ToList<Class>;


            var response = new ServiceResponse<List<Class>>();

            try
            {
                //response.Data = await _classCollection.Find(_ => true).ToListAsync();
                response.Data = await _classCollection.Find(x=>x.Id != null).ToListAsync();
                response.Message = "Successfully retrieved classes";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = $"Failed to retrieve class. Error {ex.Message}";
            }

            return response;
           
        }

       
    }
}
