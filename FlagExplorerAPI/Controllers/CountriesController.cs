using System;
using FlagExplorerAPI.Interfaces;
using FlagExplorerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlagExplorerAPI.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return Ok(await _countryService.GetAllCountriesAsync());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CountryDetails>> GetCountryByName(string name)
        {
            var country = await _countryService.GetCountryByNameAsync(name);
            return country is not null ? Ok(country) : NotFound();
        }
    }
}

