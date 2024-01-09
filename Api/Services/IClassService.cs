using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IClassService
    {
        Task<ServiceResponse<List<Class>>> GetAsync();


        Task<ServiceResponse<Class>> CreateCourseAsync(Class course);
    }
}
