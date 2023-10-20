using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly());
        });

        services.AddMapsterConfig();

        return services;
    }

    public static IServiceCollection AddMapsterConfig(
       this IServiceCollection services)
    {
        TypeAdapterConfig<Course, CourseDto>.NewConfig().MaxDepth(2).PreserveReference(true);
        TypeAdapterConfig<Review, ReviewDto>.NewConfig().MaxDepth(2).PreserveReference(true);

        return services;
    }
}
