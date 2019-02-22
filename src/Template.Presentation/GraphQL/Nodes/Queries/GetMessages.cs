using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Types;
using Template.Business.Commands.Messages;
using Template.Presentation.GraphQL.Nodes.Types;
using Template.Presentation.GraphQL.Nodes.Types.Base;
using Template.Presentation.GraphQL.Types;
using Template.Presentation.GraphQL.Types.Parameters;
using GetMessagesParameterModel = Template.Business.Models.Parameters.GetMessagesParameter;

namespace Template.Presentation.GraphQL.Nodes.Queries
{
    public class GetMessages : IQuery, IHasArgument
    {
        private readonly IGetMessages _getMessages;

        public Type Type => typeof(MessagePagination);

        public string Name => "getMessages";

        public string Description => "Returns all the existent messages.";

        public string ArgumentName => "parameter";

        public string ArgumentDescription => "The parameter used to filter the messages.";

        public Type ArgumentType => typeof(GetMessagesParameter);

        public GetMessages(IGetMessages getMessages)
        {
            _getMessages = getMessages;
        }

        public object Resolve(ResolveFieldContext context)
        {
            var parameter = context.GetArgument<GetMessagesParameterModel>("parameter");
            return _getMessages.Execute(parameter).ToTask();
        }

        private class MessagePagination : Pagination<Message>
        {
        }
    }
}
