using Shared;

namespace BlazorApp.Client.Services.ClassesService
{
    public interface IClassesService
    {
        event Action ClassesChanged;

        List<Class> Classes { get; set; }

        Task GetClasses();
    }
}
