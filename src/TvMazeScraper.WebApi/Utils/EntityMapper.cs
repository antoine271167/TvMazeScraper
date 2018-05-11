#region [ Using ]

using AutoMapper;

#endregion

namespace TvMazeScraper.WebApi.Utils
{
    internal static class EntityMapper
    {
        public static TTarget Map<TTarget>(this object source)
        {
            return _mapper.Map<TTarget>(source);
        }

        private static readonly IMapper _mapper;
        
        static EntityMapper()
        {
            _mapper =
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Domain.Entities.Show, Models.ShowModel>();
                }).CreateMapper();
        }
    }
}