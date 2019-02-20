using System.Collections.Generic;
using System.Linq;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Main
{
    public sealed class Node<TNode> : ObjectGraphType<object> where TNode : IHasBasics
    {
        public Node(IEnumerable<TNode> nodes)
        {
            var builder = new GraphFieldBuilder();

            foreach (TNode node in nodes)
            {
                AddField(builder.WithNode(node).Build());
            }
        }
    }
}
