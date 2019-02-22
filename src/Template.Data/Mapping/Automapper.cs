using System;
using System.Reactive.Linq;
using AutoMapper;

namespace Template.Data.Mapping
{
    public class Automapper : IAutomapper
    {
        private readonly IMapper _mapper;

        public Automapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IObservable<TDestination> Execute<TSource, TDestination>(TSource input)
        {
            return Observable.Return(_mapper.Map<TSource, TDestination>(input));
        }
    }
}
