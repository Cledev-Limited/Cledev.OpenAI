using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.NET.SDK.V1;

namespace OpenAI.NET.SDK.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCledevOpenAI(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.Configure<OpenAISettings>(configuration.GetSection("OpenAI"));
        services.AddOptions<OpenAISettings>();
        services.AddHttpClient<IOpenAIService, OpenAIService>();
        return services;
    }

    public static IServiceCollection AddCledevOpenAI(this IServiceCollection services, Action<OpenAISettings> setupAction)
    {
        services.AddOptions<OpenAISettings>().Configure(setupAction);
        services.AddHttpClient<IOpenAIService, OpenAIService>();
        return services;
    }
}
