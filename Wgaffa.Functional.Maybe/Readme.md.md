# Maybe

## Installing
`Install-Package Wgaffa.Functional.Maybe`

## Creating Maybe
There are a few ways to create some `Maybe<T>` types.
### Factory methods
```csharp
var someInt = Maybe<int>.Some(42);
var NoneInt = Maybe<int>.None();
```
### Implicit conversion
```csharp

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTk5MTQ3MjYwMiwtMTIyNTAyODUxMV19
-->