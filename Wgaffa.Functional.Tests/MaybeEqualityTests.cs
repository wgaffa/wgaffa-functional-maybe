using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wgaffa.Functional.Tests
{
    [TestFixture]
    public class MaybeEqualityTests
    {
        [Test]
        public void Equals_ShouldReturnFalse_GivenType()
        {
            Maybe<int> maybeInt = 5;

            Assert.That(maybeInt.Equals(5), Is.False);
        }

        [Test]
        public void Equals_ShouldReturnFalse_GivenNone()
        {
            Maybe<int> maybeInt = 3;

            Assert.That(maybeInt.Equals(Maybe<int>.None()), Is.False);
        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenBothAreNone()
        {
            Maybe<int> none = Maybe<int>.None();

            Assert.That(none.Equals(Maybe<int>.None()), Is.True);
        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenBothAreSomeAndHaveSameValue()
        {
            Maybe<int> maybeFive = 5;
            Maybe<int> maybeOtherFive = 5;

            Assert.That(maybeFive.Equals(maybeOtherFive), Is.True);
        }
    }
}
