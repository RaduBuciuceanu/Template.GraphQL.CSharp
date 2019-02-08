using System;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface IArgumentNode
    {
        string ArgumentName { get; }

        string ArgumentDescription { get; }

        Type ArgumentType { get; }
    }
}
