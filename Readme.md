![GitHub](https://img.shields.io/github/license/wgaffa/wgaffa-functional-maybe) ![Nuget](https://img.shields.io/nuget/v/Wgaffa.Functional.Maybe)

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

`Reduce` either returns the underlying value or if None a specified default value.
```csharp
var customer = maybeCustomer.Reduce(new Customer()); // Either the Customer in maybeCustomer or a new default Customer
var customerWithFunctor = maybeCustomer.Reduce(() => new Customer());
```

`OfType<T>` tries to convert from type TOld to T, if it can't it returns a None of type T
```csharp
Maybe<Car> someCar = new Car();
Maybe<IVehicle> carVehicle = someCar.OfType<IVehicle>();

Maybe<Car> noCar = None.Value();
Maybe<IVehicle> noVehicle = noCar.OfType<IVehicle>();

Maybe<IVehicle> noTruck = someCar.OfType<Truck>(); // None<IVehicle>
```