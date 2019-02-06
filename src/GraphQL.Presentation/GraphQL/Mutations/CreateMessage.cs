﻿using System;
using System.Reactive.Threading.Tasks;
using GraphQL.Business.Commands;
using GraphQL.Presentation.Main.GraphQL.Contract;
using GraphQL.Presentation.Main.GraphQL.Types;
using GraphQL.Types;
using MessageInput = GraphQL.Presentation.Main.GraphQL.Types.Inputs.MessageInput;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;

namespace GraphQL.Presentation.Main.GraphQL.Mutations
{
    public class CreateMessage : IMutation
    {
        private readonly ICreateMessage _createMessage;

        public Type Type => typeof(Message);

        public string Name => "createMessage";

        public string Description => "Creates a message and returns the created one.";

        public string ArgumentName => "input";

        public string ArgumentDescription => "The message to be created.";

        public Type ArgumentType => typeof(MessageInput);

        public CreateMessage(ICreateMessage createMessage)
        {
            _createMessage = createMessage;
        }

        public object Resolve(ResolveFieldContext context)
        {
            var input = context.GetArgument<MessageInputModel>("input");
            return _createMessage.Execute(input).ToTask();
        }
    }
}