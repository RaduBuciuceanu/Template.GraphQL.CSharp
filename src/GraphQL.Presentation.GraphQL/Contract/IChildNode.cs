using System;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface IChildNode : IParentNode
    {
        Type Type { get; }

        object Resolve(ResolveFieldContext context);
    }
}