#region [ Using ]

using System.Threading.Tasks;
using TvMazeScraper.Domain.Entities;

#endregion

namespace TvMazeScraper.Infra.Repositories
{
    public interface ITvMazeDownloadRepository
    {
        Task<Show[]> GetShowsAsync(int lastId);
    }
}