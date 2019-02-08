using System;

namespace GraphQL.Presentation.GraphQL.Contract
{
    public interface IHasArgument
    {
        string ArgumentName { get; }

        string ArgumentDescription { get; }

        Type ArgumentType { get; }
    }
}
