using Microsoft.Extensions.Configuration;

namespace ApiLocksmith.Core.Options;

/// <summary>
/// Helper class for loading ApiKeyOptions from configuration.
/// </summary>
public class ApiKeyOptionsLoader
{
    /// <summary>
    /// Loads ApiKey options from the configuration.
    /// </summary>
    /// <param name="config">The configuration containing ApiKey authentication settings.</param>
    /// <param name="authConfigSectionKey">The configuration section key for ApiKey authentication.</param>
    /// <returns>An instance of <see cref="ApiKeyOptions"/> with values from the configuration.</returns>
    /// <exception cref="InvalidOperationException">Thrown when ApiKey options are not set in the appsettings.json.</exception>
    public static ApiKeyOptions LoadFromConfiguration(IConfiguration config, string authConfigSectionKey)
    {
        var apiKeyOptions = new ApiKeyOptions();
        config.GetSection(authConfigSectionKey).Bind(apiKeyOptions);
        ValidateApiKeyOptions(apiKeyOptions);
        return apiKeyOptions;
    }

    private static void ValidateApiKeyOptions(ApiKeyOptions apiKeyOptions)
    {
        if (apiKeyOptions.ApiKeySchemeName is null || apiKeyOptions.ApiKeyHeaderName is null || apiKeyOptions.ApiKey is null)
            throw new InvalidOperationException("Api key options not set in the appsettings.json");
    }
}