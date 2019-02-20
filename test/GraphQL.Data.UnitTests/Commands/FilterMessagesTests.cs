using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Business.Models.Parameters;
using GraphQL.Data.Commands;
using GraphQL.Data.Entities;
using Shouldly;
using Xunit;

namespace GraphQL.Data.UnitTests.Commands
{
    public class FilterMessagesTests
    {
        private readonly GetMessagesParameter _parameter = new GetMessagesParameter { Id = "Random id here." };
        private readonly IQueryable<Message> _allMessages;
        private readonly IFilterMessages _instance;

        public FilterMessagesTests()
        {
            _allMessages = BuildAllMessages();
            _instance = new FilterMessages();
        }

        [Fact]
        public void With_Returns_Itself()
        {
            IFilterMessages actual = _instance.With(_parameter);

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void Execute_Throws_WhenWithWasNotInvoked()
        {
            Action act = () => _instance.Execute(_allMessages).Wait().ToList();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Execute_FiltersResultById_WhenIdIsSet()
        {
            IQueryable<Message> actual = _instance.With(_parameter).Execute(_allMessages).Wait();

            actual.ShouldAllBe(entity => entity.Id == _parameter.Id);
        }

        [Fact]
        public void Execute_DoesNotFilterResultById_WhenIdIsNotSet()
        {
            _parameter.Id = null;

            IQueryable<Message> actual = _instance.With(_parameter).Execute(_allMessages).Wait();

            actual.Count().ShouldBe(_allMessages.Count());
        }

        private EnumerableQuery<Message> BuildAllMessages()
        {
            return new EnumerableQuery<Message>(new[]
            {
                new Message { Id = _parameter.Id },
                new Message { Id = "Other id here." }
            });
        }
    }
}
