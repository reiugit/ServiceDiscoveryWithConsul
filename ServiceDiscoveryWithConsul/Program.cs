using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());

var app = builder.Build();

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient("DiscoveryRandom");

    var logicalUrl = "http://SampleService/"; //will be resolved by Consul

    var response = await client.GetStringAsync(logicalUrl);

    return new
    {
        logicalUrl,
        physicalUrl = "The physical Url was resolved by Consul.",
        response
    };
});

app.Run();
