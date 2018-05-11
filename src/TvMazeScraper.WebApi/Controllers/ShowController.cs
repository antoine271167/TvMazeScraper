#region [ Using ]

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TvMazeScraper.Application;
using TvMazeScraper.Application.Query;
using TvMazeScraper.Infra.Utils;

#endregion

namespace TvMazeScraper.WebApi.Controllers
{
    public class ShowController : ApiController
    {
        public async Task<IEnumerable<Models.ShowModel>> Get()
        {
            var result = await _getShowsQueryHandler.HandleAsync(new ShowQueryMessage {Page = 1, PageSize = 20});
            return result.Shows?.Map<Models.ShowModel[]>();
        }

        public async Task<IEnumerable<Models.ShowModel>> Get(int page, int pageSize)
        {
            var result =
                await _getShowsQueryHandler.HandleAsync(new ShowQueryMessage {Page = page, PageSize = pageSize});
            return result.Shows?.Map<Models.ShowModel[]>();
        }

        private readonly IQueryMessageHandler<ShowQueryMessage, ShowQueryResult> _getShowsQueryHandler;

        public ShowController(IQueryMessageHandler<ShowQueryMessage, ShowQueryResult> getShowsQueryHandler)
        {
            _getShowsQueryHandler = getShowsQueryHandler;
        }
    }
}