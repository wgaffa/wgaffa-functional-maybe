using System;
using System.Collections.Generic;

namespace Wgaffa.Functional
{
    public sealed class Some<T> : Maybe<T>, IEquatable<Some<T>>
    {
        public T Value { get; }

        public Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public override Maybe<U> Map<U>(Func<T, U> functor) => new Some<U>(functor(Value));

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => functor(Value);

        public override T Reduce(T defaultValue) => Value;

        public override T Reduce(Func<T> nonePredicate) => Value;

        public override void Match(Action<T> ifSome, Action ifNone) => ifSome(Value);

        public bool Equals(Some<T> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as Some<T>);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(Some<T> left, Some<T> right) =>
            (left is null && right is null) || (!(left is null) && left.Equals(right));

        public static bool operator !=(Some<T> left, Some<T> right) => !(left == right);
    }
}
