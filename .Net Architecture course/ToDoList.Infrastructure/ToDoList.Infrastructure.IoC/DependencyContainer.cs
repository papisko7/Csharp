using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.App.Services;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Data.Repository;

namespace ToDoList.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ToDoList.Core
            services.AddScoped<IToDoService, ToDoService>();

            // ToDoList.Domain interfaces and repositories
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}