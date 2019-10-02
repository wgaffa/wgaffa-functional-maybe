using System;

namespace Wgaffa.Functional
{
    public sealed class None<T> : Maybe<T>
    {
        public override Maybe<U> Map<U>(Func<T, U> functor) => new None<U>();

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => new None<U>();

        public override T Reduce(T defaultValue) => defaultValue;
    }

    public sealed class Nothing
    {
        public static Nothing Value { get; } = new Nothing();

        private Nothing() { }
    }
}
