using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using AutoMapper;
using MessageEntity = Template.Data.Entities.Message;
using MessageModel = Template.Business.Models.Message;

namespace Template.Data.Mapping.ModelEntity
{
    [SuppressMessage("Microsoft.Performance", "CA1812", Justification = "It's used by automapper by reflection.")]
    internal class MessageMessage : IMapping
    {
        public IObservable<IProfileExpression> Execute(IProfileExpression input)
        {
            return Observable.Return(input).Do(expression => expression.CreateMap<MessageModel, MessageEntity>());
        }
    }
}
