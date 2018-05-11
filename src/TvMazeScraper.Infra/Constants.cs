namespace TvMazeScraper.Infra
{
    public static class Constants
    {
        public const string Protocol = "http";
        public const string Host = "api.tvmaze.com";
        public const int TooManyRequestsDelay = 3000;
        public const int PageSize = 250;
    }
}