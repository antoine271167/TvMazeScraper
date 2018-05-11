#region [ Using ]

using Ninject.Modules;
using TvMazeScraper.Application;
using TvMazeScraper.Deamon.Service;
using TvMazeScraper.Infra.DataStorage;
using TvMazeScraper.Infra.Repositories;
using TvMazeScraper.Infra.WebClient;

#endregion

namespace TvMazeScraper.Deamon
{
    internal class IoCModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ShowDbContext>().ToSelf();
            Bind<IJobService>().To<JobService>();
            Bind<ITvMazeWebClient>().To<TvMazeWebClient>();
            Bind<ITvMazeDownloadRepository>().To<TvMazeDownloadRepository>();
            Bind<ITvMazeStorageRepository>().To<TvMazeStorageRepository>();
            Bind<IGetShowsCommandHandler>().To<GetShowsCommandHandler>();
        }
    }
}