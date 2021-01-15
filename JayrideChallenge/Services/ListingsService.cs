using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JayrideChallenge.Interfaces;
using JayrideChallenge.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JayrideChallenge.Services
{
    public class ListingsService: IListingsService
    {
        public async Task<ListingsVm> GetListings(int passengers)
        {
            var listingsEndpoint = $"https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest";
            var listingsClient = new HttpClient();
            listingsClient.DefaultRequestHeaders.Accept.Clear();
            listingsClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var listingsResponse = await listingsClient.GetAsync(listingsEndpoint);
            if (listingsResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Reason: {listingsResponse.ReasonPhrase}");
            }

            var responseContent = await listingsResponse.Content.ReadAsStringAsync();
            var listingsObject = JsonConvert.DeserializeObject(responseContent) as JObject;
            
            var listings = listingsObject["listings"].ToObject<List<Listing>>();
            listings = listings.Where(l => l.VehicleType.MaxPassengers >= passengers).ToList();
            listings.ForEach(l => l.TotalPrice = l.PricePerPassenger * passengers);
            return new ListingsVm
            {
                Total = listings.Count,
                Listings = listings
            };
        }
    }
}
