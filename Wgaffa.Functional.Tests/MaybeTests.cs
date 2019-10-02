using NUnit.Framework;

namespace Wgaffa.Functional.Tests
{
    [TestFixture]
    public class MaybeTests
    {
        private Maybe<int> Double(int number) => Maybe<int>.Some(number * 2);

        [Test]
        public void Some_ShouldCreateSomeRepresentation_GivenFactoryMethod()
        {
            var some = Maybe<int>.Some(42);

            Assert.That(some, Is.TypeOf<Some<int>>());
        }

        [Test]
        public void None_ShouldCreateNoneRepresentation_GivenFactoryMethod()
        {
            var none = Maybe<int>.None();

            Assert.That(none, Is.TypeOf<None<int>>());
        }

        [Test]
        public void Reduce_ShouldReturnStringifiedNumber_GivenSome()
        {
            var age = Maybe<int>.Some(39);

            string newAge = age.Map(x => x.ToString()).Reduce(string.Empty);

            Assert.That(newAge, Is.EqualTo("39"));
        }

        [Test]
        public void Reduce_ShouldReturnDefault_GivenNone()
        {
            var none = Maybe<int>.None();

            string stringify = none.Map(x => x.ToString()).Reduce("default value");

            Assert.That(stringify, Is.EqualTo("default value"));
        }

        [Test]
        public void Bind_ShouldReturnUnwrapped()
        {
            var number = Maybe<int>.Some(3);

            var result = number.Bind(Double);
            Assert.That(result, Is.TypeOf<Some<int>>());
        }

        [Test]
        public void Bind_ShouldNotDouble()
        {
            var number = Maybe<int>.None();

            var result = number.Bind(Double);

            Assert.That(result, Is.TypeOf<None<int>>());
        }
    }
}
