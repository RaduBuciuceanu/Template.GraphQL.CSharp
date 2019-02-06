using System;
using GraphQL.Types;

namespace GraphQL.Presentation.Main.GraphQL.Contract
{
    public interface INode
    {
        string Name { get; }

        string Description { get; }

        Type Type { get; }

        object Resolve(ResolveFieldContext context);
    }
}
