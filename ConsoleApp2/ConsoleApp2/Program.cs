// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.Metrics;
using System.Globalization;
Country[] countries = new Country[1];
string locationCode;
uint year, month;

Parse1990Code("SD1001", out countries, out locationCode, out year, out month);

static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
{
    if (string.IsNullOrEmpty(dateCode))
    {
        throw new ArgumentNullException(dateCode);
    }

    if (dateCode.Length != 6)
    {
        throw new ArgumentException(dateCode);
    }
    string yr = "19" + dateCode[3].ToString() + dateCode[5];
    string mon;
    string country;
    mon = dateCode[2].ToString() + dateCode[4].ToString();
    country = dateCode[0].ToString() + dateCode[1].ToString();
    manufacturingYear = Convert.ToUInt32(yr, CultureInfo.InvariantCulture);
    manufacturingMonth = Convert.ToUInt32(mon, CultureInfo.InvariantCulture);
    if (manufacturingMonth < 1 || manufacturingMonth > 12 || CountryParser.GetCountry(country).Length == 0 || manufacturingYear < 1990 || manufacturingYear > 2006)
    {
        throw new ArgumentException(dateCode);
    }

    factoryLocationCode = country;
    factoryLocationCountry = CountryParser.GetCountry(country);
}

public enum Country
{
    France,
    Germany,
    Italy,
    Spain,
    Switzerland,
    USA,
}

public static class CountryParser
{
    /// <summary>
    /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
    /// </summary>
    /// <param name="factoryLocationCode">A two-letter factory location code.</param>
    /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
    public static Country[] GetCountry(string factoryLocationCode)
    {
        if (string.IsNullOrEmpty(factoryLocationCode))
        {
            throw new ArgumentNullException(factoryLocationCode);
        }

        List<Country> countries = new List<Country>();
        switch (factoryLocationCode)
        {
            case "A0":
            case "A1":
            case "A2":
            case "AA":
            case "AH":
            case "AN":
            case "AR":
            case "AS":
            case "BA":
            case "BJ":
            case "BU":
            case "DR":
            case "DU":
            case "DT":
            case "CO":
            case "CT":
            case "CX":
            case "ET":
            case "MB":
            case "MI":
            case "NO":
            case "RA":
            case "RI":
            case "SF":
            case "SL":
            case "SN":
            case "SP":
            case "SR":
            case "TA":
            case "TJ":
            case "TH":
            case "TN":
            case "TR":
            case "TS":
            case "VI":
            case "VX":
                countries.Add(Country.France);
                break;
            case "LP":
            case "OL":
                countries.Add(Country.Germany);
                break;
            case "BO":
            case "CE":
            case "FN":
            case "FO":
            case "MA":
            case "NZ":
            case "OB":
            case "PL":
            case "RC":
            case "RE":
            case "TD":
                countries.Add(Country.Italy);
                break;
            case "CA":
            case "LO":
            case "LB":
            case "LM":
            case "GI":
            case "UB":
                countries.Add(Country.Spain);
                break;
            case "DI":
            case "FA":
                countries.Add(Country.Switzerland);
                break;
            case "FC":
            case "FH":
            case "OS":
            case "TX":
                countries.Add(Country.USA);
                break;
            case "SA":
                countries.Add(Country.France); countries.Add(Country.Italy); break;
            case "BC": countries.Add(Country.Italy); countries.Add(Country.Spain); break;
            case "LW": countries.Add(Country.France); countries.Add(Country.Spain); break;
            case "SD":
            case "LA":
            case "FL":
                countries.Add(Country.France); countries.Add(Country.USA); break;
            default:
                break;
        }

        return countries.ToArray();
    }
}