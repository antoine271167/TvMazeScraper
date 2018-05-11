using System;
using TvMazeScraper.Application;
using TvMazeScraper.Application.Query;
using TvMazeScraper.Infra.DataStorage;
using TvMazeScraper.Infra.Repositories;
using TvMazeScraper.Infra.WebClient;
using Unity;

namespace TvMazeScraper.WebApi
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ShowDbContext>();
            container.RegisterType<ITvMazeWebClient, TvMazeWebClient>();
            container.RegisterType<ITvMazeDownloadRepository, TvMazeDownloadRepository>();
            container.RegisterType<ITvMazeStorageRepository, TvMazeStorageRepository>();
            container.RegisterType<IQueryMessageHandler<ShowQueryMessage, ShowQueryResult>, GetShowsQueryHandler>();
        }
    }
}