using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JayrideChallenge.Interfaces;
using JayrideChallenge.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JayrideChallenge.Services
{
    public class LocationService: ILocationService
    {
        private readonly IConfiguration _configuration;

        public LocationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Location> SearchIpLocation(IPDetails ip)
        {
            var accessKey = _configuration["IpStackApiKey"];
            var locationEndpoint = $"http://api.ipstack.com/{ip.IP}?access_key={accessKey}";
            var locationClient = new HttpClient();
            locationClient.DefaultRequestHeaders.Accept.Clear();
            locationClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var locationResponse = await locationClient.GetAsync(locationEndpoint);
            if (locationResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Reason: {locationResponse.ReasonPhrase}");
            }

            var responseContent = await locationResponse.Content.ReadAsStringAsync();
            var loc = JsonConvert.DeserializeObject<Location>(responseContent);
            return loc;
        }
    }
}
