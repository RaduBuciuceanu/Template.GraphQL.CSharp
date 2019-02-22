using System.Collections.Generic;
using GraphQL.Types;
using Template.Presentation.GraphQL.Nodes.Types.Base;

namespace Template.Presentation.GraphQL.Main
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
