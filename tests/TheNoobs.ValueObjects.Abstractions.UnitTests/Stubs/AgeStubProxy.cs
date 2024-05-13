using System.Diagnostics.CodeAnalysis;

namespace TheNoobs.ValueObjects.Abstractions.UnitTests.Stubs;

[ExcludeFromCodeCoverage]
public class AgeStubProxy : AgeStub
{
    public AgeStubProxy(int age)
        : base(age)
    {
    }
}
