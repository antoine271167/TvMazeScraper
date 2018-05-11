#region [ Using ]

using System.Threading.Tasks;

#endregion

namespace TvMazeScraper.Application
{
    public interface ICommandHandler
    {
        Task HandleAsync();
    }
}