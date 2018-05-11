#region [ Using ]

using AutoMapper;
using Newtonsoft.Json;
using TvMazeScraper.Domain.Entities;
using TvMazeScraper.Infra.WebClient.Models;

#endregion

namespace TvMazeScraper.Infra.Utils
{
    public static class EntityMapper
    {
        public static TTarget Map<TTarget>(this object source)
        {
            return _mapper.Map<TTarget>(source);
        }

        private static readonly IMapper _mapper;

        static EntityMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShowModel, Show>();
                cfg.CreateMap<DataStorage.Entities.Show, Show>().ForMember(
                    dest => dest.Cast, opt => opt.ResolveUsing(src => JsonToPersonArray(src.Cast)));
                cfg.CreateMap<Show, DataStorage.Entities.Show>().ForMember(
                    dest => dest.Cast, opt => opt.ResolveUsing(src => PersonArrayJsonTo(src.Cast)));
            }).CreateMapper();
        }

        private static Person[] JsonToPersonArray(string json)
        {
            return JsonConvert.DeserializeObject<Person[]>(json);
        }

        private static string PersonArrayJsonTo(Person[] persons)
        {
            return JsonConvert.SerializeObject(persons);
        }
    }
}