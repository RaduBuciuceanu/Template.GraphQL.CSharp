﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Template.Presentation.GraphQL.Main;
using Template.Presentation.GraphQL.Nodes.Types;

namespace Template.Presentation.Startup.Ioc
{
    internal class Graph : ISetup
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(RegisterMutations)
                .Do(RegisterQueries)
                .Do(RegisterSubscriptions)
                .Do(services => services.AddScoped<Node<IMutation>>())
                .Do(services => services.AddScoped<Node<IQuery>>())
                .Do(services => services.AddScoped<Node<ISubscription>>())
                .Do(services => services.AddScoped<Schema, GraphSchema>());
        }

        private void RegisterMutations(IServiceCollection services)
        {
            foreach (Type mutationType in Discover<IMutation>())
            {
                services.AddScoped(typeof(IMutation), mutationType);
            }
        }

        private void RegisterQueries(IServiceCollection services)
        {
            foreach (Type queryType in Discover<IQuery>())
            {
                services.AddScoped(typeof(IQuery), queryType);
            }
        }

        private void RegisterSubscriptions(IServiceCollection services)
        {
            foreach (Type subscriptionType in Discover<ISubscription>())
            {
                services.AddScoped(typeof(ISubscription), subscriptionType);
            }
        }

        private IEnumerable<Type> Discover<TType>()
        {
            return GetType()
                .Assembly
                .GetTypes()
                .Where(typeof(TType).IsAssignableFrom)
                .Where(type => !type.IsAbstract);
        }
    }
}
