using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphQL.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQL.Presentation.UnitTests.GraphQL.Nodes.Base
{
    internal class ContextBuilder<TContext> where TContext : ResolveFieldContext<object>, new()
    {
        private readonly TContext _instance;

        private string _json;

        public ContextBuilder()
        {
            _instance = new TContext();
        }

        public ContextBuilder<TContext> WithJson(string jsonPath)
        {
            _json = File.ReadAllText(jsonPath);
            return this;
        }

        public TContext Build()
        {
            _instance.Arguments = DeepCast(Deserialize(_json));
            return _instance;
        }

        private static Dictionary<string, object> DeepCast(Dictionary<string, object> target)
        {
            var result = new Dictionary<string, object>();

            foreach (var pair in target)
            {
                if (pair.Value is JObject jObject && jObject.HasValues)
                {
                    result[pair.Key] = DeepCast(Deserialize(jObject));
                }
                else if (pair.Value is JArray jArray)
                {
                    result[pair.Key] = CastArray(jArray);
                }
                else
                {
                    result[pair.Key] = pair.Value;
                }
            }

            return result;
        }

        private static object CastArray(JArray jArray)
        {
            if (jArray.Any() && jArray.First.Type == JTokenType.Object)
            {
                return DeepCastArray(jArray);
            }

            return DeserializePrimitives(jArray);
        }

        private static List<Dictionary<string, object>> DeepCastArray(JArray jArray)
        {
            List<Dictionary<string, object>> deserializedArray = Deserialize(jArray);
            var result = new List<Dictionary<string, object>>();

            foreach (var dictionary in deserializedArray)
            {
                result.Add(DeepCast(dictionary));
            }

            return result;
        }

        private static Dictionary<string, object> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

        private static Dictionary<string, object> Deserialize(JObject jObject)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(jObject.ToString());
        }

        private static List<Dictionary<string, object>> Deserialize(JArray jArray)
        {
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jArray.ToString());
        }

        private static List<object> DeserializePrimitives(JArray jArray)
        {
            return JsonConvert.DeserializeObject<List<object>>(jArray.ToString());
        }
    }
}
