using System;
using System.Reactive.Linq;
using AutoMapper;
using MessageEntity = Template.Data.Entities.Message;
using MessageModel = Template.Business.Models.Message;

namespace Template.Data.Mapping.ModelEntity
{
    internal class MessageMessage : IMapping
    {
        public IObservable<IProfileExpression> Execute(IProfileExpression input)
        {
            return Observable.Return(input).Do(expression => expression.CreateMap<MessageModel, MessageEntity>());
        }
    }
}
