using ApiLocksmith.Core.Extensions;
using ApiLocksmith.Swagger.FastEndpoints.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
const string authSectionKey = "Auth";

// Add services to the container.

builder.Services
    .AddAuthorization()
    .AddFastEndpoints()
    .AddApiKeyAuthenticationScheme(builder.Configuration, authSectionKey) // add this
    .AddSwaggerDocumentWithApiKeyAuth(builder.Configuration, authSectionKey); // add this

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen(); // important for swagger

app.UseHttpsRedirection();

app.Run();