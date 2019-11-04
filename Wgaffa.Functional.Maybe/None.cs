using System;

namespace Wgaffa.Functional
{
    public sealed class None<T> : Maybe<T>, IEquatable<None<T>>, IEquatable<None>
    {
        public override Maybe<U> Map<U>(Func<T, U> functor) => new None<U>();

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => new None<U>();

        public override T Reduce(T defaultValue) => defaultValue;

        public override T Reduce(Func<T> nonePredicate) => nonePredicate();

        public override void Match(Action<T> ifSome, Action ifNone) => ifNone();

        public bool Equals(None<T> other) => other == null ? false : true;

        public bool Equals(None other) => other == null ? false : true;

        public override bool Equals(object obj) =>
            !(obj is null) && ((obj is None<T>) || (obj is None));

        public override int GetHashCode() => 0;

        public static bool operator ==(None<T> left, None<T> right) =>
            (left is null && right is null) || (!(left is null) && left.Equals(right));

        public static bool operator !=(None<T> left, None<T> right) => !(left == right);
    }

    public sealed class None : IEquatable<None>
    {
        public static None Value { get; } = new None();

        private None() { }

        public bool Equals(None other) => other == null ? false : true;

        public override bool Equals(object obj) =>
            !(obj is null) && (obj is None) || IsGenericNone(obj.GetType());

        private bool IsGenericNone(Type type) =>
            type.GenericTypeArguments.Length == 1
            && typeof(None<>).MakeGenericType(type.GenericTypeArguments[0]) == type;


        public override int GetHashCode() => 0;
    }
}
