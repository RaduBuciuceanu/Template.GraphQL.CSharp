using Newtonsoft.Json.Linq;

namespace Template.Presentation.GraphQL.Main
{
    public class GraphQuery
    {
        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}
