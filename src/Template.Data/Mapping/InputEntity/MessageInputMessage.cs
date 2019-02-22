using System;
using System.Reactive.Linq;
using AutoMapper;
using Template.Business.Models.Inputs;
using MessageEntity = Template.Data.Entities.Message;

namespace Template.Data.Mapping.InputEntity
{
    internal class MessageInputMessage : IMapping
    {
        public IObservable<IProfileExpression> Execute(IProfileExpression input)
        {
            return Observable.Return(input).Do(expression => expression.CreateMap<MessageInput, MessageEntity>());
        }
    }
}
