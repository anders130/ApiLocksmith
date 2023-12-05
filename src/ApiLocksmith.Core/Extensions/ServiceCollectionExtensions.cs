using ApiLocksmith.Core.Authentication;
using ApiLocksmith.Core.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiLocksmith.Core.Extensions;

/// <summary>
/// Extension methods for configuring ApiKey-based authentication in ASP.NET Core.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds ApiKey-based authentication scheme to the IServiceCollection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the authentication scheme to.</param>
    /// <param name="config">The configuration containing ApiKey authentication settings.</param>
    /// <param name="authConfigSectionKey">The configuration section key for ApiKey authentication.</param>
    /// <param name="configureOptions">An optional action to configure the authentication scheme options.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> to chain additional calls.</returns>

    public static IServiceCollection AddApiKeyAuthenticationScheme(this IServiceCollection services, IConfiguration config, string authConfigSectionKey, Action<AuthenticationSchemeOptions>? configureOptions = null)
    {
        var apiKeyOptions = ApiKeyOptionsLoader.LoadFromConfiguration(config, authConfigSectionKey);
        services.Configure<ApiKeyOptions>(config.GetSection(authConfigSectionKey));
        var authBuilder = services.AddAuthentication(apiKeyOptions.ApiKeySchemeName);
        authBuilder.AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(apiKeyOptions.ApiKeySchemeName, configureOptions);
        return services;
    }
}
