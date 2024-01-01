using Microsoft.Extensions.DependencyInjection;

namespace TaskManagerPractice.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            // options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            // options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}