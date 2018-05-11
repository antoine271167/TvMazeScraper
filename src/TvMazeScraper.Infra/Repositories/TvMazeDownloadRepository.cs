#region [ Using ]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Domain.Entities;
using TvMazeScraper.Infra.Utils;
using TvMazeScraper.Infra.WebClient;

#endregion

namespace TvMazeScraper.Infra.Repositories
{
    public class TvMazeDownloadRepository : ITvMazeDownloadRepository
    {
        public async Task<Show[]> GetShowsAsync(int lastId)
        {
            var page = lastId == 0 ? 0 : (int) Math.Floor((decimal) (lastId + 1) / Constants.PageSize);
            var showModels = await _client.GetShowsAsync(page);
            if (showModels != null)
            {
                var shows = new List<Show>();
                foreach (var showModel in showModels.Where(x => x.Id > lastId))
                {
                    var showDomain = showModel.Map<Show>();
                    var personModels = await _client.GetCastAsync(showDomain.Id);

                    // order the cast by birthday descending is a requirement
                    if (personModels != null)
                    {
                        showDomain.Cast = personModels.Map<Person[]>().OrderByDescending(x => x.BirthDay).ToArray();
                    }

                    shows.Add(showDomain);
                }

                return shows.Count == 0 ? null : shows.ToArray();
            }

            return null;
        }

        private readonly ITvMazeWebClient _client;

        public TvMazeDownloadRepository(ITvMazeWebClient client)
        {
            _client = client;
        }
    }
}