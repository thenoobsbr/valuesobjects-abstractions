# valuesobjects-abstractions
Some useful ValueObjects' abstractions.

## How to use

If you want to use a ValueObject in your application, just implement the abstraction like the below example:

```csharp
public class AgeStub : ValueObject<int>
{
    public AgeStub(int age)
        : base(age)
    {
    }
}
```


---
<3 Made with love!