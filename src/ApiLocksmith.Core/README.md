# ApiLocksmith.Core

The `ApiLocksmith.Core` library allows you to add ApiKey-based authentication to your minimal APIs built with ASP.NET Core. It provides a flexible and easy-to-use solution for securing your APIs.

## Usage

To use `ApiLocksmith.Core`, follow these steps:

1. Install the NuGet package:

    ```bash
    dotnet add package ApiLocksmith.Core
    ```

2. Configure the ApiKeyOptions inside the `appsettings.json`:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ApiKeySettings": {
        "ApiKey": "MySecretApiKey",
        "ApiKeyHeaderName": "x-api-key",
        "ApiKeySchemeName": "ApiKey"
      }
    }
    ```

3. Add this to your `Program.cs`:

    ```csharp
    builder.Services.AddApiKeyAuthenticationScheme(builder.Configuration, "ApiKeySettings");
    ```