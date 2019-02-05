using System;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Types;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Queries
{
    public class GetMessages : IQuery
    {
        public Type Type => typeof(Message);

        public string Name => "message";

        public string Description => "Returns all the existent messages.";

        public object Resolve(ResolveFieldContext context)
        {
            return new MessageModel { Author = "asd" };
        }
    }
}

