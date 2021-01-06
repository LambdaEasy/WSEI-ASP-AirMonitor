using System;

namespace AirMonitor.Util.Flow
{
    public class Either<TLeft, TRight> where TLeft : class
                                       where TRight : class
    {
        private readonly TLeft _left;
        private readonly TRight _right;

        #region Constructors

        private Either(TLeft left, TRight right)
        {
            if (left == null && right == null)
            {
                throw new ArgumentException("Either left and right are null");
            }
            if (left != null && right != null)
            {
                throw new ArgumentException("Either left and right are both not null");
            }
            _left = left;
            _right = right;
        }
        
        #endregion

        public bool IsLeft => _left != null;

        public bool IsRight => _right != null;

        public TRight Get => _right ?? throw new ArgumentException("Either is left.");

        public TLeft GetLeft => _left ?? throw new ArgumentException("Either is right.");

        public Either<TLeft, TR> Map<TR>(Func<TR> mapper) where TR : class
            => IsRight ? Right<TLeft, TR>(mapper.Invoke()) : Left<TLeft, TR>(_left);
        
        public Either<TL, TRight> MapLeft<TL>(Func<TL> mapper) where TL : class
            => IsLeft ? Left<TL, TRight>(mapper.Invoke()) : Right<TL, TRight>(_right);

        public Either<TLeft, TRight> Peek(Action<TRight> action)
        {
            if (IsRight)
            {
                action.Invoke(_right);
                return Right<TLeft, TRight>(_right);
            }
            return Left<TLeft, TRight>(_left);
        }

        public Either<TLeft, TRight> PeekLeft(Action<TLeft> action)
        {
            if (IsLeft)
            {
                action.Invoke(_left);
                return Left<TLeft, TRight>(_left);
            }
            return Right<TLeft, TRight>(_right);
        }

        #region StaticConstructors

        public static Either<TL, TR> Left<TL, TR>(TL left) where TL : class where TR : class
            => new Either<TL, TR>(left, null);
        
        public static Either<TL, TR> Right<TL, TR>(TR right) where TL : class where TR : class
            => new Either<TL, TR>(null, right);

        #endregion
    }
}