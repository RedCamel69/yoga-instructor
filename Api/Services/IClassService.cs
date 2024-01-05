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
        ServiceResponse<List<Class>> GetClasses();

        Task<ServiceResponse<List<Class>>> GetClassesAsync();
    }
}
