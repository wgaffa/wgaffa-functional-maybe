using System;

namespace Wgaffa.Functional
{
    public sealed class Some<T> : Maybe<T>
    {
        private readonly T _value;

        public Some(T value) => _value = value;

        public override Maybe<U> Map<U>(Func<T, U> functor) => new Some<U>(functor(_value));

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => functor(_value);

        public override T Reduce(T defaultValue) => _value;
    }
}
