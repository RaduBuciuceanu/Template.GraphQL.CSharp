using System;

namespace Template.Presentation.GraphQL.Nodes.Types.Base
{
    public interface IHasArgument
    {
        string ArgumentName { get; }

        string ArgumentDescription { get; }

        Type ArgumentType { get; }
    }
}
