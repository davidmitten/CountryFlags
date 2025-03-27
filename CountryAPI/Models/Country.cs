public class Flag
{
    public string Png { get; set; }
    public string Svg { get; set; }
    public string Alt { get; set; }
}

public class CountryName
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeName> NativeName { get; set; }
}

public class NativeName
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Currency
{
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class Country
{
    public CountryName Name { get; set; }
    public Flag Flags { get; set; }
    public string[] Tld { get; set; }
    public string Cca2 { get; set; }
    public string Ccn3 { get; set; }
    public string Cca3 { get; set; }
    public bool Independent { get; set; }
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public string[] Capital { get; set; }
    public string Region { get; set; }
    public Dictionary<string, string> Languages { get; set; }
    public double[] Latlng { get; set; }
    public bool Landlocked { get; set; }
    public double Area { get; set; }
    public int Population { get; set; }
}