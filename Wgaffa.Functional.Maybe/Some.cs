using System;
using System.Collections.Generic;

namespace Wgaffa.Functional
{
    public sealed class Some<T> : Maybe<T>, IEquatable<Some<T>>
    {
        private readonly T _value;

        public Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public override Maybe<U> Map<U>(Func<T, U> functor) => new Some<U>(functor(_value));

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => functor(_value);

        public override T Reduce(T defaultValue) => _value;

        public override T Reduce(Func<T> nonePredicate) => _value;

        public bool Equals(Some<T> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return EqualityComparer<T>.Default.Equals(_value, other._value);
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
            return EqualityComparer<T>.Default.GetHashCode(_value);
        }

        public static bool operator ==(Some<T> left, Some<T> right) => 
            (left is null && right is null) || (!(left is null) && left.Equals(right));

        public static bool operator !=(Some<T> left, Some<T> right) => !(left == right);
    }
}
