using System;
using System.Linq;
using System.Reactive.Linq;
using Template.Business.Models.Parameters;
using Template.Data.Entities;

namespace Template.Data.Commands.Messages
{
    public class FilterMessages : IFilterMessages
    {
        private GetMessagesParameter _parameter;

        public IFilterMessages With(GetMessagesParameter parameter)
        {
            _parameter = parameter;
            return this;
        }

        public IObservable<IQueryable<Message>> Execute(IQueryable<Message> input)
        {
            return Observable.Return(input)
                .Select(FilterById);
        }

        private IQueryable<Message> FilterById(IQueryable<Message> entities)
        {
            if (!string.IsNullOrWhiteSpace(_parameter.Id))
            {
                Message found = entities.Single(entity => entity.Id == _parameter.Id);
                return new[] { found }.AsQueryable();
            }

            return entities;
        }
    }
}
