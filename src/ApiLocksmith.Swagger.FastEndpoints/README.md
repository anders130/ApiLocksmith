# ApiLocksmith.Swagger.FastEndpoints

The `ApiLocksmith.Swagger.FastEndpoints` library extends `ApiLocksmith.Core` by providing Swagger documentation integration with the FastEndpoints library for your APIs secured with ApiKey-based authentication.

## Usage

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