using System;
using System.Reactive.Linq;
using AutoMapper;
using GraphQL.Business;
using GraphQL.Business.Models.Inputs;
using MessageEntity = GraphQL.Data.Entities.Message;

namespace GraphQL.Data.Mapping.InputEntity
{
    internal class MessageInputMessage : IMapping
    {
        public IObservable<IProfileExpression> Execute(IProfileExpression input)
        {
            return Observable.Return(input).Do(expression => expression.CreateMap<MessageInput, MessageEntity>());
        }
    }
}
