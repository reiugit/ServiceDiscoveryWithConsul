using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());

var app = builder.Build();

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient("DiscoveryRandom");

    var response = await client.GetStringAsync("http://SampleService/"); //will be resolved by Consul

    return new
    {
        response,
        LogicalUrl = "http://SampleService/",
        PhysicalUrl = "The physical Url was resolved by Consul."
    };
});

app.Run();
