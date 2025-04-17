using System;
using System.Net.Http;
using FlagExplorerAPI.Interfaces;
using FlagExplorerAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FlagExplorerAPI.Service
{
    public class CountryService : ICountryService
    {
        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var countries = await FetchAllCountriesAsync();
            return countries.Select(c => new Country
            {
                name = c.name,
                flag = c.flag
            });
        }

        public async Task<CountryDetails?> GetCountryByNameAsync(string name)
        {
            var countries = await FetchAllCountriesAsync();
            return countries.FirstOrDefault(c => c.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<IEnumerable<CountryDetails>> FetchAllCountriesAsync()
        {
            var client = new HttpClient(new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true });
            var response = await client.GetFromJsonAsync<List<ClientCountryModel>>("https://restcountries.com/v3.1/all");
            if (response == null) return Enumerable.Empty<CountryDetails>();

            return response.Select(rc => new CountryDetails
            {
                name = rc.Name.Common,
                capital = rc.Capital?.FirstOrDefault() ?? "N/A",
                population = rc.Population,
                flag = rc.Flags.Png
            });
        }
    }
}

