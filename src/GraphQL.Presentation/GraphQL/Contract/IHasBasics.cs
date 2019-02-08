using System;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface IHasBasics
    {
        string Name { get; }

        string Description { get; }

        Type Type { get; }

        object Resolve(ResolveFieldContext context);
    }
}
