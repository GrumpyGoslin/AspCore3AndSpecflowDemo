using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AspNetCore3SpecflowBehaviourTests
{
    public static class HttpContentExtension
    {

        public static string AsString(this HttpContent content)
            => content.ReadAsStringAsync().Result;
        public static TEntity AsEntity<TEntity>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<TEntity>(content.AsString());
        }
    }
}
