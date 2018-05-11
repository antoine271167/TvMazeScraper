#region [ Using ]

using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Domain.Entities;
using TvMazeScraper.Infra.DataStorage;
using TvMazeScraper.Infra.Utils;

#endregion

namespace TvMazeScraper.Infra.Repositories
{
    public class TvMazeStorageRepository : ITvMazeStorageRepository
    {
        public async Task<int> GetLastShowIdAsync()
        {
            var show = await _dbContext.Shows.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return show?.Id ?? 0;
        }

        public async Task<Show[]> GetShows(int pageIndex, int pageSize)
        {
            var startRow = (pageIndex-1) * pageSize;
            var dbShows = await _dbContext.ShowsNoTracking.OrderBy(x => x.Id).Skip(startRow).Take(pageSize)
                .ToArrayAsync();
            return dbShows?.Map<Show[]>();
        }

        public void InsertShow(Show show)
        {
            var dbShow = show.Map<DataStorage.Entities.Show>();
            _dbContext.Shows.Add(dbShow);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private readonly ShowDbContext _dbContext;

        public TvMazeStorageRepository(ShowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}