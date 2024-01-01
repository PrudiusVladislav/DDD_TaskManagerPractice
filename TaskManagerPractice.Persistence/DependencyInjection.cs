using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Users;
using TaskManagerPractice.Persistence.Interceptors;
using TaskManagerPractice.Persistence.Tasks;
using TaskManagerPractice.Persistence.Users;

namespace TaskManagerPractice.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddTransient<PublishDomainEventsInterceptor>();
        
        services.AddDbContext<TaskManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TaskManagerDatabase"),
                builder => builder.MigrationsAssembly("TaskManagerPractice.Persistence")));

        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<ITasksRepository, TasksRepository>();
        
        return services;
    }
}