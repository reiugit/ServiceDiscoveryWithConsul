# Service-Discovery with Consul

* Add Service-Discovery:<br>
  builder.Services.AddServiceDiscovery(o => o.UseConsul())

* Create HTTP-Client:<br>
  httpClientFactory.CreateClient("DiscoveryRandom")

* This HTTP-Client will automatically resolve logical Service Urls<br>
  and replace them with the previously registered physical Urls.

### Prerequisites:

* Start a Consul docker container before running the application:
<pre>
docker run -d -p 8500:8500 --name=consul hashicorp/consul
</pre>

