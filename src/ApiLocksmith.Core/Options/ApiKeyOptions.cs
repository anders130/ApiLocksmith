namespace ApiLocksmith.Core.Options;

/// <summary>
/// Options for configuring ApiKey-based authentication.
/// </summary>
public class ApiKeyOptions
{
    /// <remarks>
    /// Represents the actual API key that clients must provide for authentication.
    /// </remarks>
    public string ApiKey { get; set; } = null!;

    /// <remarks>
    /// Defines the name of the HTTP header in the incoming request where the API key is expected.
    /// </remarks>
    public string ApiKeyHeaderName { get; set; } = null!;

    /// <remarks>
    /// Specifies the name of the authentication scheme to be used for ApiKey authentication.
    /// </remarks>
    public string ApiKeySchemeName { get; set; } = null!;
}
