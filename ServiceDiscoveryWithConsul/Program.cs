using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;
using ServiceDiscoveryWithConsul.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());
builder.Services.AddExceptionHandler<HttpRequestExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    // 'DiscoveryRandom' is the name of the predefined HttpClient from the Consul configuration
    var client = httpClientFactory.CreateClient("DiscoveryRandom");

    var logicalUrl = "http://SampleService/";
    var physicalUrl = "The physical Url was resolved by Consul.";
    var response = await client.GetStringAsync(logicalUrl);

    return new { logicalUrl, physicalUrl, response };
});

app.Run();
