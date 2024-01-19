using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISimpleSignedFraction<TSelf, TValue> : ISignedFraction<TSelf, TValue>, ISimpleFraction<TSelf, TValue>
    where TSelf : ISimpleSignedFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

public interface ISimpleSignedFraction<TSelf, TValue, TMixed> : ISignedFraction<TSelf, TValue, TMixed, TSelf>, ISimpleSignedFraction<TSelf, TValue>,
        ISimpleFraction<TSelf, TValue, TMixed>
    where TSelf : ISimpleSignedFraction<TSelf, TValue, TMixed>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TMixed : IMixedSignedFraction<TMixed, TValue, TSelf>?
{ }
