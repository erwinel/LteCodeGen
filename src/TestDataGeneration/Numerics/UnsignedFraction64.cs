using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction64 : ISimpleFraction<UnsignedFraction64, uint, UnsignedMixedFraction128>
{
    #region Static Properties

    public static UnsignedFraction64 One { get; } = new(1U, 1U);

    public static UnsignedFraction64 Zero { get; } = new(0U, 1U);

    public static UnsignedFraction64 MaxValue { get; } = new(uint.MaxValue, 1U);

    public static UnsignedFraction64 MinValue { get; } = new(uint.MinValue, 1U);

    public static UnsignedFraction64 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public uint Numerator { get; }

    public uint Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedFraction64(uint numerator, uint denominator, bool doNotReduce = false)
    {
        if (doNotReduce)
        {
            if (denominator == 0) throw new DivideByZeroException();
        }
        else
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction128 Add(uint wholeNumber1, uint wholeNumber2, UnsignedFraction64 fraction2)
    {
        (uint wholeNumber, uint numerator, uint denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction64 Add(UnsignedFraction64 fraction)
    {
        (uint numerator, uint denominator) = AddSimpleFractions<UnsignedFraction64, uint>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(UnsignedFraction64 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    public UnsignedMixedFraction128 Divide(uint wholeDividend, uint wholeDivisor, UnsignedFraction64 divisorFraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction64 Divide(UnsignedFraction64 fraction)
    {
        (uint numerator, uint denominator) = DivideSimpleFractions<UnsignedFraction64, uint>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(UnsignedFraction64 other) => AreSimpleFractionsEqual<UnsignedFraction64, uint>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public UnsignedMixedFraction128 Join(uint wholeNumber) => new(wholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction128 Multiply(uint wholeMultiplier, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction64 Multiply(UnsignedFraction64 fraction)
    {
        (uint numerator, uint denominator) = MultiplySimpleFractions<UnsignedFraction64, uint>(this, fraction);
        return new(numerator, denominator);
    }

    public UnsignedMixedFraction128 Subtract(uint wholeMinuend, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction64 Subtract(UnsignedFraction64 fraction)
    {
        (uint numerator, uint denominator) = SubtractSimpleFractions<UnsignedFraction64, uint>(this, fraction);
        return new(numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0U) return double.NaN;
        if (provider is null)
            return (Numerator == 0U) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
        return (Numerator == 0U) ? Convert.ToDouble(Numerator, provider) : Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider);
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<UnsignedFraction64, uint>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static UnsignedFraction64 Abs(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(uint wholeNumber1, UnsignedFraction64 fraction1, uint wholeNumber2, UnsignedFraction64 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(UnsignedMixedFraction128 fraction1, uint wholeNumber2, UnsignedFraction64 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(uint wholeNumber1, UnsignedFraction64 fraction1, UnsignedMixedFraction128 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Add(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(uint wholeDividend, UnsignedFraction64 dividendFraction, uint wholeDivisor, UnsignedFraction64 divisorFraction, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(UnsignedMixedFraction128 dividend, uint wholeDivisor, UnsignedFraction64 divisorFraction, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(uint wholeDividend, UnsignedFraction64 dividendFraction, UnsignedMixedFraction128 divisor, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Divide(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Invert(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Invert(UnsignedFraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Log2(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MaxMagnitude(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MaxMagnitudeNumber(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MinMagnitude(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MinMagnitudeNumber(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(uint wholeMultiplier, UnsignedFraction64 multiplierFraction, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(UnsignedMixedFraction128 multiplier, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(uint wholeMultiplier, UnsignedFraction64 multiplierFraction, UnsignedMixedFraction128 multiplicand, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Multiply(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(uint wholeMinuend, UnsignedFraction64 minuendFraction, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(UnsignedMixedFraction128 minuend, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(uint wholeMinuend, UnsignedFraction64 minuendFraction, UnsignedMixedFraction128 subtrahend, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Subtract(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToProperFraction(UnsignedFraction64 value, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperFraction(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToProperSimplestForm(UnsignedFraction64 value, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToSimplestForm(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out uint numerator, out uint denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out uint numerator, out uint denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer, provider, out uint numerator, out uint denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer, provider, out uint numerator, out uint denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedFraction64>.Radix => 10;

    static UnsignedFraction64 IAdditiveIdentity<UnsignedFraction64, UnsignedFraction64>.AdditiveIdentity => Zero;

    static UnsignedFraction64 IMultiplicativeIdentity<UnsignedFraction64, UnsignedFraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction64 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode() => TypeCode.Double;

    bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(ToDouble(provider), provider);

    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(ToDouble(provider), provider);

    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(ToDouble(provider), provider);

    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(ToDouble(provider), provider);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(ToDouble(provider), provider);

    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(ToDouble(provider), provider);

    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(ToDouble(provider), provider);

    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(ToDouble(provider), provider);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(ToDouble(provider), provider);

    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(ToDouble(provider), provider);

    string IConvertible.ToString(IFormatProvider? provider) => ToFractionString(Numerator, Denominator, provider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToFractionString(Numerator, Denominator, format, formatProvider);

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedFraction64, uint>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedFraction64>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToChecked<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToSaturating<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToTruncating<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedFraction64 operator +(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator +(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator -(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator -(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ~(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ++(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator --(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator *(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator /(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator %(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator &(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator |(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ^(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
