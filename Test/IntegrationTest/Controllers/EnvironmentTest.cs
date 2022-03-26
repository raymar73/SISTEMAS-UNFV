using System.Net.Http;
using ApiCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace IntegrationTest.IntegrationTest.Controllers
{
    public class EnvironmentTest
    {
        public readonly TestServer _server;
        public readonly HttpClient _client;

        public EnvironmentTest()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseSetting("https_port", "443")
                .UseStartup<Startup>());
            _client = _server.CreateClient();    
        }
        
    }
}