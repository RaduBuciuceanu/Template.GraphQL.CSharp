﻿using System.Linq;
using System.Reactive.Linq;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;
using GraphQL.Data.Commands;
using Moq.AutoMock;

namespace GraphQL.Data.UnitTests.Repositories.Setup
{
    public class CreatePaginationSetup : AutoMockerSetup
    {
        public CreatePaginationSetup(AutoMocker mocker) : base(mocker)
        {
        }

        public CreatePaginationSetup With<TItem>(PaginationParameter parameter)
        {
            Mocker.GetMock<ICreatePagination<TItem>>()
                .Setup(command => command.With(parameter))
                .Returns(Mocker.Get<ICreatePagination<TItem>>());

            return this;
        }

        public CreatePaginationSetup With<TItem>(IQueryable<TItem> input, Pagination<TItem> output)
        {
            Mocker.GetMock<ICreatePagination<TItem>>()
                .Setup(command => command.Execute(input))
                .Returns(Observable.Return(output));

            return this;
        }
    }
}
