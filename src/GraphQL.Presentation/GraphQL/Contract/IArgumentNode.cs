using System;

namespace GraphQL.Presentation.Main.GraphQL.Contract
{
    public interface IArgumentNode
    {
        string ArgumentName { get; }

        string ArgumentDescription { get; }

        Type ArgumentType { get; }
    }
}
