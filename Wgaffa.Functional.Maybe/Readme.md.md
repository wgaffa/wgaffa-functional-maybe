# Maybe

## Installing
`Install-Package Wgaffa.Functional.Maybe`

## Creating Maybe
There are a few ways to create some `Maybe<T>` types.
### Factory methods
```csharp
var someInt = Maybe<int>.Some(42);
var noneInt = Maybe<int>.None();
```
### Implicit conversion
```csharp
Maybe<int> someInt = 42;
Maybe<int> noneInt = Nothing.Value;
```

### Calling constructors
```csharp
Maybe<int> someInt = new Some<int>(42);
Maybe<int> noneInt = 
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTkzNzA5MDY3OCwtMTIyNTAyODUxMV19
-->