using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());

var app = builder.Build();

app.MapGet("/", () =>
{
    return "This response is from SampleService.";
});

app.Run();
