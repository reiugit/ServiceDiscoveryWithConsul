using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(o => o.UseConsul());

var app = builder.Build();

//this is the service endpoint that will forwarded after the service discovery
app.MapGet("/", () =>
{
    return "This response is from 'SampleService' (discovered by Consul).";
});

try
{
    app.Run();
}
catch (HttpRequestException)
{
    Console.WriteLine("\n\nA Consul docker container has to be running in order to resolve logical Urls.");
    Console.WriteLine("You can start a Consul docker container with the following command:\n");
    Console.WriteLine("    docker run -d -p 8500:8500 --name=consul hashicorp/consul '\n\n");
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
}
