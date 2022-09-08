using MicroKnights.Gender_API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenderTiger
{
    public class GenderApi
    {
        private readonly GenderApiClient client;

        public GenderApi(String apiKey, String baseAddress = "https://gender-api.com")
        {
            this.client = new GenderApiClient(
                new HttpClient
                {
                    BaseAddress = new Uri(baseAddress)
                },
                new GenderApiConfiguration
                {
                    ApiKey = apiKey
                }
            );
        }

        public async Task<String> GetGenderByName(String name, String countryCode = "DK")
        {
            var response = await this.GetGenderNameByName(name, countryCode);
            return response.GenderType.DisplayName;
        }

        public async Task<GenderApiNameResponse> GetGenderNameByName(String name, String countryCode = "DK")
        {
            if (await this.IsLimitedReached())
            {
                throw new Exception("LIMIT IS REACHEDD!!!!!");
            }

            return await this.client.GetByNameAndCountry2Alpha(name, countryCode);
        }

        public async Task<GenderApiStatisticsResponse> GetStatistics()
        {
            return await this.client.GetStatistics();
        }

        public async Task<Boolean> IsLimitedReached()
        {
            var statistics = await this.GetStatistics();
            return statistics.IsLimitReached;
        }
    }
}