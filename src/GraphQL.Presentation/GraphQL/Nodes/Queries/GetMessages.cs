using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Business.Commands;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Types;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Nodes.Queries
{
    public class GetMessages : IQuery
    {
        private readonly IGetMessages _getMessages;

        public Type Type => typeof(Message);

        public string Name => "message";

        public string Description => "Returns all the existent messages.";

        public GetMessages(IGetMessages getMessages)
        {
            _getMessages = getMessages;
        }

        public object Resolve(ResolveFieldContext context)
        {
            return _getMessages.Execute().ToTask();
        }
    }
}
