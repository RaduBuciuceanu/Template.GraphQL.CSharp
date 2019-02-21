using System;
using System.Reactive.Linq;
using AutoMapper;
using GraphQL.Business;
using MessageEntity = GraphQL.Data.Entities.Message;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Data.Mapping.ModelEntity
{
    internal class MessageMessage : IMapping
    {
        public IObservable<IProfileExpression> Execute(IProfileExpression input)
        {
            return Observable.Return(input).Do(expression => expression.CreateMap<MessageModel, MessageEntity>());
        }
    }
}
