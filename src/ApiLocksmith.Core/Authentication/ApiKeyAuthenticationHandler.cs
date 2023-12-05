using ApiLocksmith.Core.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace ApiLocksmith.Core.Authentication;

/// <summary>
/// Authentication handler for ApiKey-based authentication in ASP.NET Core.
/// </summary>
/// <param name="options">The monitor for the authentication scheme options.</param>
/// <param name="logger">The logger factory for creating loggers.</param>
/// <param name="encoder">The URL encoder.</param>
/// <param name="apiKeyOptions">The options for ApiKey-based authentication.</param>

public class ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IOptions<ApiKeyOptions> apiKeyOptions)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    private readonly string _apiKey = apiKeyOptions.Value.ApiKey;
    private readonly string _headerName = apiKeyOptions.Value.ApiKeyHeaderName;

    /// <summary>
    /// Handles the authentication process asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing the result of the authentication.</returns>
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        Request.Headers.TryGetValue(_headerName, out var extractedApiKey);

        if (!IsPublicEndpoint() && !extractedApiKey.Equals(_apiKey))
            return Task.FromResult(AuthenticateResult.Fail("Invalid Api Credentials!"));

        var identity = new ClaimsIdentity(
            claims: new[] { new Claim("ClientID", "Default") },
            authenticationType: Scheme.Name);
        var principal = new GenericPrincipal(identity, roles: null);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    /// <summary>
    /// Checks whether the current endpoint is public or requires authentication.
    /// </summary>
    /// <returns>true if the endpoint is public; otherwise, false.</returns>
    private bool IsPublicEndpoint() => Context
        .GetEndpoint()?.Metadata
        .OfType<AllowAnonymousAttribute>()
        .Any() is null or true;
}