using System;
using System.Collections.Generic;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


namespace AspNetCore3SpecflowBehaviourTests.Contexts
{
    public static class EntityExtensions
    {
        public static string ToJson<T>(this T entity)
        {
            return JsonConvert.SerializeObject(entity, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(false, true)
                },
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                }
            });

        }
    }
}
