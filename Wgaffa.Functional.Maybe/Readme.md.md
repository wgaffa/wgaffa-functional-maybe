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
Maybe<int> noneInt = new None<int>();
```

## Using Maybe's
`Map` takes a type and returns a `Maybe<T>` much like LINQ `Select`.
```csharp
var customerId = Maybe<int>.Some(42);
var customerMaybe = customerId.Map(id => new Customer(id)); // Maybe<Customer>
```

`Bind` takes a functor returning another maybe and chains everything together much like LINQ `SelectMany`.
```csharp
var customer = repository.FindCustomer(42); // Returning a Maybe<Customer>
var orders = customer.Bind(c => repository.FindOrder(c.orderId)); // FindOrder() returns a Maybe<Order>
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTQxODAyMDkyMSwtMTIyNTAyODUxMV19
-->