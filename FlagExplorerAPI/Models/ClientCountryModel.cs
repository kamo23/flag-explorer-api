using System;
namespace FlagExplorerAPI.Models
{
	public class ClientCountryModel 
    {
    public Name Name { get; set; } = default!;
        public List<string>? Capital { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; } = default!;
        public FlagUrls Flags { get; set; } = default!;
    }

    public class Name
    {
        public string Common { get; set; } = default!;
    }

    public class FlagUrls
    {
        public string Png { get; set; } = default!;
        public string Svg { get; set; } = default!;
    }
}

