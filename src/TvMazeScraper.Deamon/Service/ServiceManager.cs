#region [ Using ]

#endregion

namespace TvMazeScraper.Deamon.Service
{
    internal class ServiceManager
    {
        public void Start()
        {
            _jobService.Start();
        }

        public void Stop()
        {
            _jobService.Stop();
        }

        private readonly IJobService _jobService;

        public ServiceManager(IJobService jobService)
        {
            _jobService = jobService;
        }
    }
}