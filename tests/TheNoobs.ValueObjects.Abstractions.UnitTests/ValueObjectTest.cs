using AutoFixture.Xunit2;
using FluentAssertions;
using TheNoobs.ValueObjects.Abstractions.UnitTests.Stubs;
using Xunit;

namespace TheNoobs.ValueObjects.Abstractions.UnitTests;

[Trait("Category", "UnitTests")]
[Trait("Class", nameof(ValueObject))]
public class ValueObjectTest
{
    [Theory]
    [InlineData("BRA", "BRA", true)]
    [InlineData("BRA", "PRT", false)]
    [InlineData("PRT", "EUA", false)]
    public void Given_ACountryValueObject_When_ItComparedWithAnotherCountry_Then_TheResultShouldBeAsExpected(
        string countryCode1, string countryCode2, bool expectedResult)
    {
        var country1 = CountryStub.Get(countryCode1);
        var country2 = CountryStub.Get(countryCode2);
        (country1 == country2).Should().Be(expectedResult);
        (country2 == country1).Should().Be(expectedResult);
        country1.Equals(country2).Should().Be(expectedResult);
        country2.Equals(country1).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(25, 25, true)]
    [InlineData(26, 25, false)]
    public void Given_AnAgeValueObject_When_ItComparedWithAnotherAge_Then_TheResultShouldBeAsExpected(int numAge1, int numAge2, bool expectedResult)
    {
        var age1 = new AgeStub(numAge1);
        var age2 = new AgeStub(numAge2);
        (age1 == age2).Should().Be(expectedResult);
        (age2 == age1).Should().Be(expectedResult);
        age1.Equals(age2).Should().Be(expectedResult);
        age2.Equals(age1).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(25, 25, true)]
    [InlineData(26, 25, false)]
    public void Given_AnAgeValueObjectAsObject_When_ItComparedWithAnotherAge_Then_TheResultShouldBeAsExpected(int numAge1, int numAge2, bool expectedResult)
    {
        object age1 = new AgeStub(numAge1);
        object age2 = new AgeStub(numAge2);
        age1.Equals(age2).Should().Be(expectedResult);
        age2.Equals(age1).Should().Be(expectedResult);
    }

    [Theory]
    [AutoData]
    public void Given_AValueObject_When_GetsTheHashCode_Then_ItShouldBeCorrectlyCalculated(string code)
    {
        var zipCode = new ZipCodeStub(code, CountryStub.Brazil);
        zipCode.GetHashCode().Should().Be(code.GetHashCode() ^ CountryStub.Brazil.GetHashCode());
        zipCode.ToString().Should().Be($"{code};{CountryStub.Brazil}");
    }

    [Fact]
    public void Given_AValueObject_WhenComparesToAValueObjectOfAnotherType_Then_TheResultShouldNotBeEquals()
    {
        var age = new AgeStub(38);
        var anotherAge = new AnotherAgeStub(38);
        var country = CountryStub.Brazil;
        var zipCode = new ZipCodeStub("25900-001", CountryStub.Brazil);

        zipCode.Equals(age).Should().BeFalse();
        zipCode.Equals(anotherAge).Should().BeFalse();
        zipCode.Equals(country).Should().BeFalse();

        country.Equals(age).Should().BeFalse();
        country.Equals(anotherAge).Should().BeFalse();
        country.Equals(zipCode).Should().BeFalse();

        age.Equals(anotherAge).Should().BeFalse();
        age.Equals(country).Should().BeFalse();
        age.Equals(zipCode).Should().BeFalse();
    }

    [Fact]
    public void Given_AValueObject_WhenComparesToNullValue_Then_TheResultShouldNotBeEquals()
    {
        var age1 = new AgeStub(10);
        AgeStub? age2 = null;
        (age1 == age2!).Should().BeFalse();
        (age1 != age2!).Should().BeTrue();
        age1.Equals(age2).Should().BeFalse();

        var country1 = CountryStub.Brazil;
        CountryStub? country2 = null;
        (country1 == country2!).Should().BeFalse();
        (country1 != country2!).Should().BeTrue();
        country1.Equals(country2).Should().BeFalse();

        var zipCode1 = new ZipCodeStub("25900-001", CountryStub.Brazil);
        ZipCodeStub? zipCode2 = null;
        (zipCode1 == zipCode2!).Should().BeFalse();
        (zipCode1 != zipCode2!).Should().BeTrue();
        zipCode1.Equals(zipCode2).Should().BeFalse();
    }

    [Fact]
    public void Given_AValueObject_WhenComparesToNullValueOfAnotherType_Then_TheResultShouldNotBeEquals()
    {
        var age = new AgeStub(38);
        CountryStub? country = null;
        ZipCodeStub? zipCode = null;

        age.Equals(country).Should().BeFalse();
        age.Equals(zipCode).Should().BeFalse();
    }

    [Fact]
    public void Given_AValueObjectAsObject_WhenComparesToAValueObjectOfAnotherType_Then_TheResultShouldNotBeEquals()
    {
        object age = new AgeStub(38);
        object anotherAge = new AnotherAgeStub(38);
        object country = CountryStub.Portugal;
        object zipCode = new ZipCodeStub("25900-001", CountryStub.Brazil);

        zipCode.Equals(age).Should().BeFalse();
        zipCode.Equals(anotherAge).Should().BeFalse();
        zipCode.Equals(country).Should().BeFalse();

        country.Equals(age).Should().BeFalse();
        country.Equals(anotherAge).Should().BeFalse();
        country.Equals(zipCode).Should().BeFalse();

        age.Equals(anotherAge).Should().BeFalse();
        age.Equals(country).Should().BeFalse();
        age.Equals(zipCode).Should().BeFalse();
    }

    [Fact]
    public void Given_TwoNullValueObject_WhenCompares_Then_TheResultShouldBeTrue()
    {
        AgeStub? age1 = null;
        AgeStub? age2 = null;
        (age1! == age2!).Should().BeTrue();

        CountryStub? country1 = null;
        CountryStub? country2 = null;
        (country1! == country2!).Should().BeTrue();

        ZipCodeStub? zipCode1 = null;
        ZipCodeStub? zipCode2 = null;
        (zipCode1! == zipCode2!).Should().BeTrue();
    }

    [Fact]
    public void Given_AValueObject_WhenComparesToAProxiedItself_Then_TheResultShouldBeTrue()
    {
        AgeStub age1 = new AgeStub(1);
        AgeStubProxy age2 = new AgeStubProxy(1);
        
        (age1 == age2).Should().BeTrue();
    }
}
