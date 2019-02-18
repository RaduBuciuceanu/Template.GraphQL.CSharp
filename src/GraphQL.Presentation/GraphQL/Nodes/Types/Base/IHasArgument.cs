using System;

namespace GraphQL.Presentation.GraphQL.Nodes.Types.Base
{
    public interface IHasArgument
    {
        string ArgumentName { get; }

        string ArgumentDescription { get; }

        Type ArgumentType { get; }
    }
}
