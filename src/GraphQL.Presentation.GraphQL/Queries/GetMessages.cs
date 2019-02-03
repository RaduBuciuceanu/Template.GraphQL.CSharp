using System;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Queries
{
    public class GetMessages : IQuery
    {
        public Type Type => typeof(Message);

        public string Name => "message";

        public string Description => "description";

        public object Resolve(ResolveFieldContext context)
        {
            throw new NotImplementedException();
        }
    }
}