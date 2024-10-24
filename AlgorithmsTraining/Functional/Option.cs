using static AlgorithmsTraining.Functional.F;

namespace AlgorithmsTraining.Functional
{
    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value); // wrap the given value into a Some

        public static Option.None None => Option.None.Default;  // the None value
    }

    public readonly struct Option<T> : IEquatable<Option.None>, IEquatable<Option<T>>
    {
        private readonly T _value;
        private readonly bool _isSome;

        private readonly bool _isNone => !_isSome;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);

        public static implicit operator Option<T>(T value)
           => value == null ? None : Some(value);

        public readonly R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value) : None();

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome) yield return _value;
        }

        public bool Equals(Option<T> other)
           => _isSome == other._isSome
           && (_isNone || null != _value && _value.Equals(other._value));

        public bool Equals(Option.None _) => _isNone;

        public override bool Equals(object? obj) => null != obj && obj is Option<T> option && Equals(option);

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);

        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        public override readonly string ToString() => _isSome ? $"Some({_value})" : "None";

        public override int GetHashCode() => base.GetHashCode();
    }

    namespace Option
    {
        public readonly struct None
        {
            internal static readonly None Default = new();
        }

        public readonly struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value)
                       , "Cannot wrap a null value in a 'Some'; use 'None' instead");
                Value = value;
            }
        }
    }

    public static class OptionExt
    {
        public static Option<R> Bind<T, R>
         (this Option<T> optT, Func<T, Option<R>> f)
          => optT.Match(
             () => None,
             (t) => f(t));

        public static bool IsSome<T>(this Option<T> @this)
         => @this.Match(
            () => false,
            (_) => true);

        public static T ValueUnsafe<T>(this Option<T> @this)
           => @this.Match(
              () => { throw new InvalidOperationException(); },
              (t) => t);
    }
}