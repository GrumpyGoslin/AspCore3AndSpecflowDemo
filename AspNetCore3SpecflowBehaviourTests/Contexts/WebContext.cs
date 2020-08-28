using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore3SpecflowBehaviourTests.Contexts
{
    public class WebContext : ISystemUnderTest
    {

        public HttpClient Client { get; set; }
        public async Task PostAsync<T>(string route, T entity)
        {
            Response = await Client.PostAsync(route, new StringContent(entity.ToJson(), Encoding.UTF8, "application/json"));
        }

        public HttpResponseMessage Response { get; private set; }
        public async Task PutAsync<T>(string route, T entity)
        {
            Response = await Client.PutAsync(route, new StringContent(entity.ToJson(), Encoding.UTF8, "application/json"));
        }

        public async Task GetAsync(string route)
        {
            Response = await Client.GetAsync(route);
        }

    }
}
