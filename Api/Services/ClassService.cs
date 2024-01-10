using Api.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

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

        public async Task<ServiceResponse<Class>> CreateClassAsync(Class newClass)
        {
            var response = new ServiceResponse<Class>();

            try
            {
                await _classCollection.InsertOneAsync(newClass);
                
                response.Data = newClass;
                response.Message = "Successfully added new class";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = $"Failed to add new class. Error {ex.Message}";
            }

            return response;
        }

            public async Task<ServiceResponse<List<Class>>> GetAsync()
        {

           
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

        public async Task<ServiceResponse<Class>> GetClassAsync(string Id)
        {
            var response = new ServiceResponse<Class>();
            try
            {
                //response.Data = await _classCollection.Find(_ => true).ToListAsync();
                response.Data = await _classCollection.Find(x => x.Id == Id).FirstOrDefaultAsync();
                response.Message = "Successfully retrieved class";
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

        public async Task<ServiceResponse<Class>> UpdateClassAsync(Class cl)
        {
            var response = new ServiceResponse<Class>();

            try
            {
                var filter = Builders<Class>.Filter.Eq("Id", cl.Id);
                var update = Builders<Class>.Update.Set(x => x,cl);

                await _classCollection.ReplaceOneAsync(filter, cl);

                response.Data = cl;
                response.Message = "Successfully updated class";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = $"Failed to update class. Error {ex.Message}";
            }

            return response;
        }
    }
}
