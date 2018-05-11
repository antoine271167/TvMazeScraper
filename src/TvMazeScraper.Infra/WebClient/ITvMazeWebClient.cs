#region [ Using ]

using System.Threading.Tasks;
using TvMazeScraper.Infra.WebClient.Models;

#endregion

namespace TvMazeScraper.Infra.WebClient
{
    public interface ITvMazeWebClient
    {
        Task<PersonModel[]> GetCastAsync(int showId);
        Task<ShowModel[]> GetShowsAsync(int page);
    }
}