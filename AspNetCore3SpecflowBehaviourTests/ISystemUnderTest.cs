using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCore3SpecflowBehaviourTests
{
    public interface ISystemUnderTest
    {
        Task PostAsync<T>(string route, T entity);
        HttpResponseMessage Response { get; }
        Task PutAsync<T>(string route, T entity);
        Task GetAsync(string route);
    }
}
