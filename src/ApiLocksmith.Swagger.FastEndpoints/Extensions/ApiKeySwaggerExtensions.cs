using ApiLocksmith.Core.Options;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace ApiLocksmith.Swagger.FastEndpoints.Extensions;

/// <summary>
/// Extension methods for configuring Swagger with ApiKey authentication in FastEndpoints.
/// </summary>
public static class ApiKeySwaggerExtensions
{
    /// <summary>
    /// Adds Swagger document configuration with ApiKey authentication.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the Swagger configuration to.</param>
    /// <param name="config">The configuration containing ApiKey settings.</param>
    /// <param name="authConfigSectionKey">The configuration section key for ApiKey authentication.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddSwaggerDocumentWithApiKeyAuth(this IServiceCollection services, IConfiguration config, string authConfigSectionKey)
    {
        var apiKeyOptions = ApiKeyOptionsLoader.LoadFromConfiguration(config, authConfigSectionKey);
        services.SwaggerDocument(o =>
        {
            o.EnableJWTBearerAuth = false;
            o.DocumentSettings = s => s.AddAuth(apiKeyOptions.ApiKeySchemeName, new OpenApiSecurityScheme
            {
                Name = apiKeyOptions.ApiKeyHeaderName,
                In = OpenApiSecurityApiKeyLocation.Header,
                Type = OpenApiSecuritySchemeType.ApiKey,
            });
        });
        return services;
    }
}