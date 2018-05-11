#region [ Using ]

using System.Threading.Tasks;

#endregion

namespace TvMazeScraper.Application
{
    public interface IQueryMessageHandler<in TMessage, TResult>
    {
        Task<TResult> HandleAsync(TMessage queryMessage);
    }
}