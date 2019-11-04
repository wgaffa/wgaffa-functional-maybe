using System;

namespace Wgaffa.Functional
{
    public abstract class Maybe<T>
    {
        public static Some<T> Some(T value) => new Some<T>(value);
        public static None<T> None() => new None<T>();

        public static implicit operator Maybe<T>(T value) => new Some<T>(value);
        public static implicit operator Maybe<T>(None _) => new None<T>();

        public abstract Maybe<U> Map<U>(Func<T, U> functor);
        public abstract Maybe<U> Bind<U>(Func<T, Maybe<U>> functor);

        public abstract T Reduce(T defaultValue);
        public abstract T Reduce(Func<T> nonePredicate);

        public abstract void Match(Action<T> ifSome, Action ifNone);
    }
}
