# valuesobjects-abstractions
Some useful ValueObjects' abstractions.

[![Nuget](https://buildstats.info/nuget/RestSharp.Authenticators.Digest)](http://www.nuget.org/packages/RestSharp.Authenticators.Digest)
![License](https://img.shields.io/github/license/bernardbr/RestSharp.Authenticators.Digest)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_valuesobjects-abstractions&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_valuesobjects-abstractions)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_valuesobjects-abstractions&metric=bugs)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_valuesobjects-abstractions)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_valuesobjects-abstractions&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_valuesobjects-abstractions)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_valuesobjects-abstractions&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_valuesobjects-abstractions)

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
> :green_heart: Made with love!
