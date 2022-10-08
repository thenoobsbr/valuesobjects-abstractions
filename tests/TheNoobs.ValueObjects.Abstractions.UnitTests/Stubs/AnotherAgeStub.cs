using System.Diagnostics.CodeAnalysis;

namespace TheNoobs.ValueObjects.Abstractions.UnitTests.Stubs;

[ExcludeFromCodeCoverage]
public class AnotherAgeStub : ValueObject<int>
{
    public AnotherAgeStub(int age)
        : base(age)
    {
    }
}
