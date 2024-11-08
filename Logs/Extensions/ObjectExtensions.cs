using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Logs
{
    public static class ObjectExtensions
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings;

        static ObjectExtensions()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static string ToJson(this object target)
        {
            return JsonConvert.SerializeObject(target, JsonSerializerSettings);
        }
    }
}