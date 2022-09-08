using MicroKnights.Gender_API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenderTiger
{
    public class GenderApi
    {
   
        public GenderApi()
        {
  

        }
        public async Task<string> RunTests(GenderApiClient client, string Name, string CountryCode)
        {
            var responseStats = await client.GetStatistics();
           
                Console.WriteLine($"IsLimitReached: {responseStats.IsLimitReached}");
                Console.WriteLine($"Remaning requests: {responseStats.RemaningRequests}");

                var responseName = await client.GetByNameAndCountry2Alpha(Name, CountryCode);
            Console.WriteLine(responseName);
            var result = Convert.ToString(responseName.GenderType.DisplayName);
     
            return result;

    
        }

      
        public GenderApiClient PlainConsole()
        {
            // client is thread-safe, and can be used static.
            var client = new GenderApiClient(
                new HttpClient
                {
                    BaseAddress = new Uri("https://gender-api.com")
                },
                new GenderApiConfiguration
                {
                    ApiKey = "LQ3YexQLXBmFjXgU5LvBS5hGBPUjTNAcVqUX"
        });
            return client;
        }
    }
}