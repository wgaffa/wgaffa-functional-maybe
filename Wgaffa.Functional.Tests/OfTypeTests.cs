using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wgaffa.Functional.Tests
{
    public class OfTypeTests
    {
        public interface IVehicle { }
        public class Car : IVehicle { }
        public class Truck : IVehicle { }

        [Test]
        public void OfType_ShouldReturnSome_GivenDerivedObject()
        {
            Maybe<Car> someCar = new Car();

            Maybe<IVehicle> result = someCar.OfType<IVehicle>();

            Assert.That(result, Is.TypeOf<Some<IVehicle>>());
        }

        [Test]
        public void OfType_ShouldReturnNone_GivenNone()
        {
            Maybe<Car> noCar = None.Value;

            Maybe<IVehicle> result = noCar.OfType<IVehicle>();

            Assert.That(result, Is.TypeOf<None<IVehicle>>());
        }

        [Test]
        public void OfType_ShouldreturnNone_WhenNotAssignable()
        {
            Maybe<Car> someCar = new Car();

            Maybe<Truck> result = someCar.OfType<Truck>();

            Assert.That(result, Is.TypeOf<None<Truck>>());
        }
    }
}
