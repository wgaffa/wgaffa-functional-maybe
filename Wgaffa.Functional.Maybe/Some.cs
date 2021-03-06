﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Wgaffa.Functional
{
    public sealed class Some<T> : Maybe<T>, IEquatable<Some<T>>
    {
        [NotNull] public T Content { get; }

        public Some(T content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public override Maybe<U> Map<U>(Func<T, U> functor) => new Some<U>(functor(Content));

        public override Maybe<U> Bind<U>(Func<T, Maybe<U>> functor) => functor(Content);

        public override T Reduce(T defaultValue) => Content;

        public override T Reduce(Func<T> nonePredicate) => Content;

        public override void Match(Action<T> ifSome, Action ifNone) => ifSome(Content);

        public bool Equals(Some<T>? other)
        {
            if (other == null)
                return false;

            return ReferenceEquals(this, other) 
                   || EqualityComparer<T>.Default.Equals(Content, other.Content);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as Some<T>);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Content);
        }

        public static bool operator ==(Some<T>? left, Some<T>? right) => 
            (left is null && right is null) || (!(left is null) && left.Equals(right));

        public static bool operator !=(Some<T> left, Some<T> right) => !(left == right);
    }
}
