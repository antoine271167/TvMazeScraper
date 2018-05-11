#region [ Using ]

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
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
            try
            {
                var result = await _getShowsQueryHandler.HandleAsync(new ShowQueryMessage {Page = 1, PageSize = 20});
                return result.Shows?.Map<Models.ShowModel[]>();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public async Task<IEnumerable<Models.ShowModel>> Get(int page, int pageSize)
        {
            try
            {
                var result =
                    await _getShowsQueryHandler.HandleAsync(new ShowQueryMessage {Page = page, PageSize = pageSize});
                return result.Shows?.Map<Models.ShowModel[]>();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        private readonly IQueryMessageHandler<ShowQueryMessage, ShowQueryResult> _getShowsQueryHandler;
        private readonly ILog _log = LogManager.GetLogger(nameof(ShowController));

        public ShowController(IQueryMessageHandler<ShowQueryMessage, ShowQueryResult> getShowsQueryHandler)
        {
            _getShowsQueryHandler = getShowsQueryHandler;
        }
    }
}