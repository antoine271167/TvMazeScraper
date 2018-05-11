#region [ Using ]

using System;
using System.Threading.Tasks;
using TvMazeScraper.Domain.Entities;
using TvMazeScraper.Infra.Repositories;

#endregion

namespace TvMazeScraper.Application
{
    public class GetShowsCommandHandler : IGetShowsCommandHandler
    {
        public async Task HandleAsync()
        {
            Console.WriteLine($"running command {typeof(GetShowsCommandHandler).Name}");
            _stop = false;
            var lastId = await _tvMazeStorageRepository.GetLastShowIdAsync();
            Show[] shows;
            do
            {
                Console.Write($"downloading: lastId={lastId} ... ");
                shows = await _tvMazeDownloadRepository.GetShowsAsync(lastId);
                Console.Write("done\n");

                if (shows != null)
                {
                    foreach (var show in shows)
                    {
                        if (_stop)
                        {
                            break;
                        }

                        _tvMazeStorageRepository.InsertShow(show);
                        lastId = show.Id;
                    }

                    Console.Write("storing ... ");
                    await _tvMazeStorageRepository.SaveAsync();
                    Console.Write("done\n");
                }

                if (_stop)
                {
                    break;
                }
            } while (shows != null);

            Console.WriteLine($"completed command {typeof(GetShowsCommandHandler).Name}");
        }

        public void Stop()
        {
            _stop = true;
        }

        private readonly ITvMazeDownloadRepository _tvMazeDownloadRepository;
        private readonly ITvMazeStorageRepository _tvMazeStorageRepository;
        private bool _stop;

        public GetShowsCommandHandler(ITvMazeDownloadRepository tvMazeDownloadRepository,
            ITvMazeStorageRepository tvMazeStorageRepository)
        {
            _tvMazeDownloadRepository = tvMazeDownloadRepository;
            _tvMazeStorageRepository = tvMazeStorageRepository;
        }
    }
}