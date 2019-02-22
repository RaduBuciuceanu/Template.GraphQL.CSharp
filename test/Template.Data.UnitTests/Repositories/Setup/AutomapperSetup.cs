using System;
using System.Linq.Expressions;
using System.Reactive.Linq;
using Moq.AutoMock;
using Template.Business.Models;
using Template.Data.Mapping;

namespace Template.Data.UnitTests.Repositories.Setup
{
    public class AutomapperSetup : AutoMockerSetup
    {
        public AutomapperSetup(AutoMocker mocker) : base(mocker)
        {
        }

        public AutomapperSetup With<TSource, TDestination>(TSource input, TDestination output)
        {
            Mocker.GetMock<IAutomapper>()
                .Setup(instance => instance.Execute<TSource, TDestination>(input))
                .Returns(Observable.Return(output));

            return this;
        }

        public AutomapperSetup WithPagination<TSource, TDestination>(Pagination<TSource> input,
            Pagination<TDestination> output)
        {
            Mocker.GetMock<IAutomapper>()
                .Setup(PagedExpression<TSource, TDestination>(input))
                .Returns(Observable.Return(output));

            return this;
        }

        private static Expression<Func<IAutomapper, IObservable<Pagination<TDestination>>>> PagedExpression<
            TSource, TDestination>(Pagination<TSource> input)
        {
            return instance => instance.Execute<Pagination<TSource>, Pagination<TDestination>>(input);
        }
    }
}
