using Newtonsoft.Json.Linq;

namespace GraphQL.Presentation.Main.Dtos
{
    public class GraphQuery
    {
        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}
