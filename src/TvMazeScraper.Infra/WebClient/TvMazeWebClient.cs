#region [ Using ]

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TvMazeScraper.Infra.WebClient.Models;

#endregion

namespace TvMazeScraper.Infra.WebClient
{
    public class TvMazeWebClient : ITvMazeWebClient
    {
        public async Task<PersonModel[]> GetCastAsync(int showId)
        {
            while (true)
            {
                var response = await _client.GetAsync($"shows/{showId}/cast");
                if (response.IsSuccessStatusCode)
                {
                    var cast = JsonConvert.DeserializeObject<CastModel[]>(
                        await response.Content.ReadAsStringAsync());
                    return cast?.Select(x => x.Person).ToArray();
                }

                if (response.StatusCode == (HttpStatusCode) 429)
                {
                    // 429 Too many requests, back off a few seconds and try again
                    await Task.Delay(Constants.TooManyRequestsDelay);
                    continue;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new HttpException((int) response.StatusCode, "Too many requests");
            }
        }

        public async Task<ShowModel[]> GetShowsAsync(int page)
        {
            while (true)
            {
                var response = await _client.GetAsync($"shows?page={page}");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ShowModel[]>(
                        await response.Content.ReadAsStringAsync());
                }

                if (response.StatusCode == (HttpStatusCode) 429)
                {
                    // 429 Too many requests, back off a few seconds and try again
                    await Task.Delay(Constants.TooManyRequestsDelay);
                    continue;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new HttpException((int) response.StatusCode, "Too many requests");
            }
        }

        private readonly HttpClient _client;

        public TvMazeWebClient()
        {
            _client = new HttpClient {BaseAddress = new Uri($"{Constants.Protocol}://{Constants.Host}/")};
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}