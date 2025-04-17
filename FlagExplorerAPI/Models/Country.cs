using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Country
	{
		public string name { get; set; } = string.Empty;
		public string flag{ get; set; } = string.Empty;
	}

	public class CountryDetails : Country
	{
		public int population { get; set; }
		public string capital { get; set; } = string.Empty;
    }
}

