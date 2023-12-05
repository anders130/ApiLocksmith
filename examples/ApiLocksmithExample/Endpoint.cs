using FastEndpoints;

namespace ApiLocksmithExample;

public sealed class Endpoint : EndpointWithoutRequest
{
    public override void Configure() => Get("protected");
    public override async Task HandleAsync(CancellationToken ct) => await SendAsync("You are authorized!", cancellation: ct);
}
