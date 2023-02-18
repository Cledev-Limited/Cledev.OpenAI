using Cledev.OpenAI.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cledev.OpenAI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenAIClient(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.Configure<Settings>(configuration.GetSection("OpenAI"));
        services.AddOptions<Settings>();
        services.AddHttpClient<IOpenAIClient, OpenAIClient>();
        return services;
    }

    public static IServiceCollection AddOpenAIClient(this IServiceCollection services, Action<Settings> setupAction)
    {
        services.AddOptions<Settings>().Configure(setupAction);
        services.AddHttpClient<IOpenAIClient, OpenAIClient>();
        return services;
    }
}
