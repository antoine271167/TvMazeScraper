#region [ Using ]

using Topshelf;
using Topshelf.Unity;
using TvMazeScraper.Deamon.Service;

#endregion

namespace TvMazeScraper.Deamon
{
    internal class Program
    {
        private static void Main()
        {
            // using topshelf to create a windows service that is easy to deploy
            // and can run in command-line mode for debugging purposes.
            HostFactory.Run(x =>
            {
                x.UseUnityContainer(IoCContainerFactory.Create());
                x.Service<ServiceManager>(s =>
                {
                    s.ConstructUsingUnityContainer();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("TvMazeScraper Service");
                x.SetDisplayName("TvMazeScraper");
                x.SetServiceName("TvMazeScraper");
            });
        }
    }
}