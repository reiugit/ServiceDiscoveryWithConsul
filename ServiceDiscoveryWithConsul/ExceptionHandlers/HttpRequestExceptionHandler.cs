using Microsoft.AspNetCore.Diagnostics;

namespace ServiceDiscoveryWithConsul.ExceptionHandlers;

public class HttpRequestExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not HttpRequestException)
        {
            return false;
        }

        await httpContext.Response.WriteAsJsonAsync(new
        {
            Error = "A Consul docker container has to be running in order to resolve the logical Url.",
            Resolution = "docker run -d -p 8500:8500 --name=consul hashicorp/consul"
        },
        cancellationToken);

        return true;
    }
}
