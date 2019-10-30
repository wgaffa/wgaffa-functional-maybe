using System;

namespace Wgaffa.Functional
{
    public sealed class None<T> : Maybe<T>, IEquatable<None<T>>
    {
        public override Maybe<U> Map<U>(Func<T, U> functor) => new None<U>();

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => new None<U>();

        public override T Reduce(T defaultValue) => defaultValue;

        public override T Reduce(Func<T> nonePredicate) => nonePredicate();

        public bool Equals(None<T> other) => true;

        public override bool Equals(object obj) => true;

        public override int GetHashCode() => 0;

        public static bool operator ==(None<T> left, None<T> right) =>
            (left is null && right is null) || (!(left is null) && left.Equals(right));

        public static bool operator !=(None<T> left, None<T> right) => !(left == right);
    }

    public sealed class Nothing
    {
        public static Nothing Value { get; } = new Nothing();

        private Nothing() { }
    }
}
