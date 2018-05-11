#region [ Using ]

using TvMazeScraper.Application;
using TvMazeScraper.Deamon.Service;
using TvMazeScraper.Infra.DataStorage;
using TvMazeScraper.Infra.Repositories;
using TvMazeScraper.Infra.WebClient;
using Unity;

#endregion

namespace TvMazeScraper.Deamon
{
    public static class IoCContainerFactory
    {
        public static UnityContainer Create()
        {
            var container = new UnityContainer();
            container.RegisterType<ShowDbContext>();
            container.RegisterType<IJobService, JobService>();
            container.RegisterType<ITvMazeWebClient, TvMazeWebClient>();
            container.RegisterType<ITvMazeDownloadRepository, TvMazeDownloadRepository>();
            container.RegisterType<ITvMazeStorageRepository, TvMazeStorageRepository>();
            container.RegisterType<IGetShowsCommandHandler, GetShowsCommandHandler>();
            return container;
        }
    }
}