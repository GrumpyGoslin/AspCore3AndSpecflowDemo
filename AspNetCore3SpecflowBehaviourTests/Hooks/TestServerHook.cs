using AspNetCore3SpecflowBehaviourTests.Contexts;
using AspNetCore3SpecflowService;
using Autofac.Extensions.DependencyInjection;
using BoDi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace AspNetCore3SpecflowBehaviourTests.Hooks
{
    [Binding]
    public class TestServerHook
    {
        private readonly WebContext _context;
        private static HttpClient _client;

        public TestServerHook(WebContext context, IObjectContainer objectContainer)
        {
            _context = context;
            objectContainer.RegisterInstanceAs<ISystemUnderTest>(context);
        }

        [BeforeTestRun(Order = 1)]
        public static void BeforeTestRun()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                });

            var host = hostBuilder.Start();

            _client = host.GetTestClient();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _context.Client = _client;
        }
    }
}
