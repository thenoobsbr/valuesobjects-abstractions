using System.Diagnostics.CodeAnalysis;

namespace TheNoobs.ValueObject.Abstractions.UnitTests.Stubs;

[ExcludeFromCodeCoverage]
public class CountryStub : ValueObject
{
    private static readonly IDictionary<string, CountryStub> _countries;

    static CountryStub()
    {
        _countries = new Dictionary<string, CountryStub>(3)
        {
            {"BRA", new CountryStub("BRA", "Brazil")},
            {"EUA", new CountryStub("EUA", "United of States of America")},
            {"PRT", new CountryStub("PRT", "Portugal")}
        };
    }

    private CountryStub(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public static CountryStub Brazil => _countries["BRA"];

    public static CountryStub Eua => _countries["EUA"];

    public static CountryStub Portugal => _countries["PRT"];

    public string Code { get; }

    public string Name { get; }

    public static CountryStub Get(string countryCode)
    {
        return _countries[countryCode];
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
    }
}
