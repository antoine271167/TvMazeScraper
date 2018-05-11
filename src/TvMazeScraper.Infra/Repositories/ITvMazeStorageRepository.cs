#region [ Using ]

using System.Threading.Tasks;
using TvMazeScraper.Domain.Entities;

#endregion

namespace TvMazeScraper.Infra.Repositories
{
    public interface ITvMazeStorageRepository
    {
        void InsertShow(Show show);
        Task<int> GetLastShowIdAsync();
        Task SaveAsync();
        Task<Show[]> GetShows(int page, int pageSize);
    }
}