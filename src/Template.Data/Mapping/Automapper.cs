using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using AutoMapper;

namespace Template.Data.Mapping
{
    [SuppressMessage("Microsoft.Performance", "CA1724", Justification = "It's an application wide convention.")]
    public class Automapper : IAutomapper
    {
        private readonly IMapper _mapper;

        public Automapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IObservable<TDestination> Execute<TSource, TDestination>(TSource source)
        {
            return Observable.Return(_mapper.Map<TSource, TDestination>(source));
        }
    }
}
