using System;
using System.Linq;
using System.Reactive.Linq;
using Shouldly;
using Template.Business.Models;
using Template.Business.Models.Parameters;
using Template.Data.Commands;
using Xunit;

namespace Template.Data.UnitTests.Commands
{
    public class CreatePaginationTests
    {
        private readonly PaginationParameter _parameter = new PaginationParameter { PageIndex = 1, PageSize = 1 };
        private readonly IQueryable<object> _items = new[] { new object(), new object(), new object() }.AsQueryable();
        private readonly ICreatePagination<object> _instance;

        public CreatePaginationTests()
        {
            _instance = new CreatePagination<object>();
        }

        [Fact]
        public void With_Returns_Itself()
        {
            ICreatePagination<object> actual = _instance.With(_parameter);

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void Execute_Throws_WhenWithWasNotInvoked()
        {
            Action act = () => _instance.Execute(_items).Wait();

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Execute_ItemsAwayFromRange_AreNotSelected()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.Items.ShouldNotContain(_items.First());
            actual.Items.ShouldNotContain(_items.Last());
        }

        [Fact]
        public void Execute_ItemsInRange_AreSelected()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.Items.ShouldAllBe(instance => instance == _items.ElementAt(1));
        }

        [Fact]
        public void Execute_ItemsCountIsRight_WhenThereAreEnoughItems()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.Items.Count().ShouldBe(_parameter.PageSize);
        }

        [Fact]
        public void Execute_ItemsCountIsRight_WhenThereAreNotEnoughItems()
        {
            _parameter.PageIndex = 0;
            _parameter.PageSize = 999;

            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.Items.Count().ShouldBe(_items.Count());
        }

        [Fact]
        public void Execute_PageIndex_IsSet()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.PageIndex.ShouldBe(_parameter.PageIndex);
        }

        [Fact]
        public void Execute_PageSize_IsSet()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.PageSize.ShouldBe(_parameter.PageSize);
        }

        [Fact]
        public void ToPagedCollection_TotalCount_IsSet()
        {
            Pagination<object> actual = _instance.With(_parameter).Execute(_items).Wait();

            actual.TotalCount.ShouldBe(_items.Count());
        }
    }
}
