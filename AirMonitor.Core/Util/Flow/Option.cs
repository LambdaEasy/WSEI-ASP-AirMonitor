using System;

namespace AirMonitor.Core.Util.Flow
{
    public class Option<TValue> where TValue : class
    {
        private readonly TValue _value;

        private Option(TValue value)
        {
            _value = value;
        }

        public bool IsEmpty => _value == null;

        public TValue Get => _value ?? throw new ArgumentException("Option value is null");

        public Option<T> Map<T>(Func<TValue, T> mapper) where T : class
            => IsEmpty ? Empty<T>() : Of(mapper.Invoke(_value));

        public Either<TLeft, TValue> ToEither<TLeft>(TLeft left) where TLeft : class
            => IsEmpty
             ? Either<TLeft, TValue>.Left<TLeft, TValue>(left)
             : Either<TLeft, TValue>.Right<TLeft, TValue>(_value);

        #region StaticConstructors

        public static Option<T> Empty<T>() where T : class => new Option<T>(null);

        public static Option<T> Of<T>(T value) where T : class => new Option<T>(value);

        #endregion
    }
}