using System.Diagnostics.CodeAnalysis;

namespace TheNoobs.ValueObjects.Abstractions.UnitTests.Stubs;

[ExcludeFromCodeCoverage]
public class AgeStub : ValueObject<int>
{
    public AgeStub(int age)
        : base(age)
    {
    }
}
