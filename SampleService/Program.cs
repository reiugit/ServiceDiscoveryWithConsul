using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());

var app = builder.Build();

//this is the service endpoint that will be called after the discovery of this service
app.MapGet("/", () =>
{
    return "This response is from SampleService.";
});

app.Run();
