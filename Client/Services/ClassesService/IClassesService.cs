using Shared;
using SharedModels;

namespace BlazorApp.Client.Services.ClassesService
{
    public interface IClassesService
    {
        event Action ClassesChanged;

        event Action FirstPageDisplayClassesChanged;
        List<Class> Classes { get; set; }

        List<Class> FirstPageDisplayClasses { get; set; }

        Task GetClasses();

        Task<Class?> GetClassById(string id);

        Task CreateClass(Class newClass);

        Task UpdateClass(Class updatedClass);
    }
}
