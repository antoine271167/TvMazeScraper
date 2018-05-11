#region [ Using ]

using System;
using System.Threading;
using System.Timers;
using log4net;
using TvMazeScraper.Application;

#endregion

namespace TvMazeScraper.Deamon.Service
{
    internal class JobService : IJobService
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(JobService));

        public void Start()
        {
            _isStopping = false;
            _timer.Interval = 100;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _isStopping = true;
            _getShowsCommandHandler?.Stop();
            if (!IsRunning())
            {
                _waitHandle.Set();
            }

            _waitHandle.WaitOne();
        }

        private static readonly AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private readonly IGetShowsCommandHandler _getShowsCommandHandler;
        private readonly System.Timers.Timer _timer;
        private bool _isBusy;
        private bool _isStopping;

        public JobService(IGetShowsCommandHandler getShowsCommandHandler)
        {
            _getShowsCommandHandler = getShowsCommandHandler;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += TimerOnElapsed;
        }

        private bool IsRunning()
        {
            return !_isStopping || _isBusy;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _timer.Interval = 1000 * 60 * 60; // check every one hour
            if (_isBusy)
            {
                return;
            }

            _isBusy = true;

            try
            {
                _getShowsCommandHandler.HandleAsync().Wait();
                throw new Exception();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
            finally
            {
                _isBusy = false;
                if (!IsRunning())
                {
                    _waitHandle.Set();
                }
            }
        }
    }
}