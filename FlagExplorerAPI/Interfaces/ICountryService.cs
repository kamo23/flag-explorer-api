using System;
using FlagExplorerAPI.Models;

namespace FlagExplorerAPI.Interfaces
{
	public interface ICountryService
	{
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<CountryDetails?> GetCountryByNameAsync(string name);
    }
}

