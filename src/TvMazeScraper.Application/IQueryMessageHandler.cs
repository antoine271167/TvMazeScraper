#region [ Using ]

using System.Threading.Tasks;

#endregion

namespace TvMazeScraper.Application
{
    public interface IQueryMessageHandler<TMessage, TResult>
    {
        Task<TResult> HandleAsync(TMessage queryMessage);
    }
}