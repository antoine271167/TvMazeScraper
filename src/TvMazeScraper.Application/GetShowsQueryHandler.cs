#region [ Using ]

using System.Threading.Tasks;
using TvMazeScraper.Application.Query;
using TvMazeScraper.Infra.Repositories;

#endregion

namespace TvMazeScraper.Application
{
    public class GetShowsQueryHandler : IQueryMessageHandler<ShowQueryMessage, ShowQueryResult>
    {
        public async Task<ShowQueryResult> HandleAsync(ShowQueryMessage queryMessage)
        {
            return new ShowQueryResult
            {
                Shows = await _tvMazeStorageRepository.GetShows(queryMessage.Page, queryMessage.PageSize)
            };
        }

        private readonly ITvMazeStorageRepository _tvMazeStorageRepository;

        public GetShowsQueryHandler(ITvMazeStorageRepository tvMazeStorageRepository)
        {
            _tvMazeStorageRepository = tvMazeStorageRepository;
        }
    }
}