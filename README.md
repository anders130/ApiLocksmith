# ApiLocksmith

ApiLocksmith is a collection of C# libraries that simplify API development with ASP.NET Core by providing easy integration of ApiKey-based authentication and Swagger documentation.

## ApiLocksmith.Core

The `ApiLocksmith.Core` library allows you to add ApiKey-based authentication to your minimal APIs built with ASP.NET Core. It provides a flexible and easy-to-use solution for securing your APIs.

### Usage

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

Refer to the [ApiLocksmith.Core documentation](./src/ApiLocksmith.Core/README.md) for detailed configuration options and usage examples.

## ApiLocksmith.Swagger.FastEndpoints

The `ApiLocksmith.Swagger.FastEndpoints` library extends `ApiLocksmith.Core` by providing Swagger documentation integration with the FastEndpoints library for your APIs secured with ApiKey-based authentication.

### Usage

To use `ApiLocksmith.Swagger.FastEndpoints`, follow these steps:

1. Install the NuGet package:

    ```bash
    dotnet add package ApiLocksmith.Swagger.FastEndpoints
    ```

2. Add this to your `Program.cs`:

    ```csharp
    builder.Services.AddSwaggerDocumentWithApiKeyAuth(builder.Configuration, "ApiKeySettings");

    // ...

    app.UseSwaggerGen();
    ```

Refer to the [ApiLocksmith.Swagger.FastEndpoints documentation](./src/ApiLocksmith.Swagger.FastEndpoints/README.md) for detailed configuration options and usage examples.

## Examples

Check out the [examples](./examples) folder for sample projects demonstrating the usage of ApiLocksmith libraries in different scenarios.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
