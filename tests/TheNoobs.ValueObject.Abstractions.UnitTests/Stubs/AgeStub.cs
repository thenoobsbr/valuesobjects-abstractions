using System.Diagnostics.CodeAnalysis;

namespace TheNoobs.ValueObject.Abstractions.UnitTests.Stubs;

[ExcludeFromCodeCoverage]
public class AgeStub : ValueObject<int>
{
    public AgeStub(int age)
        : base(age)
    {
    }
}
