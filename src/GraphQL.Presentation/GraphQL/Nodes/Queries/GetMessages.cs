using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Business.Commands;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Types;
using GetMessagesParameterModel = GraphQL.Business.Models.Parameters.GetMessagesParameter;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.GraphQL.Nodes.Queries
{
    public class GetMessages : IQuery, IHasArgument
    {
        private readonly IGetMessages _getMessages;

        public Type Type => typeof(ListGraphType<Message>);

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
    }
}
