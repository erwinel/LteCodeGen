using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;
using static TestDataGeneration.Numerics.NumberStatic;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents an IPv4 internet address.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public readonly struct IPV4Address : IConvertible, IBinaryInteger<IPV4Address>, IMinMaxValue<IPV4Address>, IUnsignedNumber<IPV4Address>
{
    #region Fields

    /// <summary>
    /// The octet separator character.
    /// </summary>
    public const char SeparatorChar = '.';

    private static readonly IPV4Address _one = new(1U);
    [FieldOffset(0)] private readonly uint _value;
    [FieldOffset(0)] private readonly byte _octet3;
    [FieldOffset(1)] private readonly byte _octet2;
    [FieldOffset(2)] private readonly byte _octet1;
    [FieldOffset(3)] private readonly byte _octet0;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the value of the first octet.
    /// </summary>
    /// <returns>The value of the first octet.</returns>
    public byte Octet0 { get { return _octet0; } }

    /// <summary>
    /// Gets the value of the second octet.
    /// </summary>
    /// <returns>The value of the second octet.</returns>
    public byte Octet1 { get { return _octet1; } }

    /// <summary>
    /// Gets the value of the third octet.
    /// </summary>
    /// <returns>The value of the third octet.</returns>
    public byte Octet2 { get { return _octet2; } }

    /// <summary>
    /// Gets the value of the fourth octet.
    /// </summary>
    /// <returns>The value of the fourth octet.</returns>
    public byte Octet3 { get { return _octet3; } }

    /// <summary>
    /// Gets the maximum IPv4 address value.
    /// </summary>
    /// <returns>The maximum IPv4 address value.</returns>
    public static IPV4Address MaxValue => new(uint.MaxValue);

    /// <summary>
    /// Gets the minimum IPv4 address value.
    /// </summary>
    /// <returns>The minimum IPv4 address value.</returns>
    public static IPV4Address MinValue => new(0u);

    #endregion

    #region Constructors

    private IPV4Address(uint value)
    {
        _octet0 = _octet1 = _octet2 = _octet3 = 0;
        _value = value;
    }

    /// <summary>
    /// Creates a new <c>IPV4Address</c> value.
    /// </summary>
    /// <param name="octet0">The value of the first octet.</param>
    /// <param name="octet1">The value of the second octet.</param>
    /// <param name="octet2">The value of the third octet.</param>
    /// <param name="octet3">The value of the fourth octet.</param>
    public IPV4Address(byte octet0, byte octet1, byte octet2, byte octet3)
    {
        _value = 0;
        _octet0 = octet0;
        _octet1 = octet1;
        _octet2 = octet2;
        _octet3 = octet3;
    }

    #endregion

    #region Instance Methods

    /// <summary>
    /// Gets a masked <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="netMask">The netmask value to use.</param>
    /// <returns>A masked <see cref="IPV4Address"/> value.</returns>
    public IPV4Address AsMasked(IPV4Address netMask) => new(_value & netMask._value);

    /// <summary>
    /// Gets the last <see cref="IPV4Address"/> value in the specified segnment.
    /// </summary>
    /// <param name="blockBitCount">The number of bits in the segment.</param>
    /// <returns>A <see cref="IPV4Address"/> value representing the last address in the specified segnment.</returns>
    public IPV4Address AsEndOfSegment(byte blockBitCount)
    {
        if (blockBitCount > IPv4CidrBlock.MAX_BLOCK_BIT_COUNT) throw new ArgumentOutOfRangeException(nameof(blockBitCount));
        return new IPV4Address(_value | uint.MaxValue << blockBitCount);
    }

    public int CompareTo(IPV4Address other) => _value.CompareTo(other._value);

    public int CompareTo(object? obj) => _value.CompareTo((obj is IPV4Address other) ? other._value : obj);

    public bool Equals(IPV4Address other) => _value.Equals(other._value);

    public override bool Equals([NotNullWhen(true)] object? obj) => _value.Equals((obj is IPV4Address other) ? other._value : obj);

    /// <summary>
    /// Gets the 32-bit IP address value from the current <see cref="IPV4Address"/>.
    /// </summary>
    /// <returns>A 32-bit IP address value from the current <see cref="IPV4Address"/>.</returns>
    public uint GetAddress() => BitConverter.ToUInt32(new byte[] { _octet0, _octet1, _octet2, _octet3 }, 0);

    public override int GetHashCode() => _value.GetHashCode();

    #endregion

    #region Static Methods

    /// <summary>
    /// Gets an <see cref="IPV4Address"/> as a netmask value.
    /// </summary>
    /// <param name="blockBitCount">The number of bits in the netmask value.</param>
    /// <returns>An <see cref="IPV4Address"/> value representing a netmask value.</returns>
    public static IPV4Address AsNetMask(byte blockBitCount)
    {
        if (blockBitCount > IPv4CidrBlock.MAX_BLOCK_BIT_COUNT) throw new ArgumentOutOfRangeException(nameof(blockBitCount));
        return new IPV4Address(uint.MaxValue >> (32 - blockBitCount));
    }

    /// <summary>
    /// Gets a <see cref="IPV4Address"/> value from a 32-bit integer value.
    /// </summary>
    /// <param name="address">The 32-bit IP address value.</param>
    /// <returns>A <see cref="IPV4Address"/> value from a 32-bit integer value.</returns>
    public static IPV4Address FromAddress(uint address)
    {
        var bytes = BitConverter.GetBytes(address);
        return new IPV4Address(bytes[3], bytes[2], bytes[1], bytes[0]);
    }

    /// <summary>
    /// Parses a span of characters into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Address"/>.</exception>
    public static IPV4Address Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider = null)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
                byte.TryParse(s0, style, provider, out byte o0) && byte.TryParse(s1, style, provider, out byte o1) && byte.TryParse(s2, style, provider, out byte o2) && byte.TryParse(s3, style, provider, out byte o3))
            return new(o0, o1, o2, o3);
        throw new FormatException($"The input string '{s}' was not in a correct format.");
    }

    /// <summary>
    /// Parses a string into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Address"/>.</exception>
    public static IPV4Address Parse(string s, NumberStyles style, IFormatProvider? provider = null)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), style, provider);
    }

    /// <summary>
    /// Parses a span of characters into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Address"/>.</exception>
    public static IPV4Address Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
                byte.TryParse(s0, provider, out byte o0) && byte.TryParse(s1, provider, out byte o1) && byte.TryParse(s2, provider, out byte o2) && byte.TryParse(s3, provider, out byte o3))
            return new(o0, o1, o2, o3);
        throw new FormatException($"The input string '{s}' was not in a correct format.");
    }

    /// <summary>
    /// Parses a string into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Address"/>.</exception>
    public static IPV4Address Parse(string s, IFormatProvider? provider = null)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), provider);
    }

    public override string ToString() => $"{_octet0}.{_octet1}.{_octet2}.{_octet3}";

    private static bool TryGetNumberSpans(ReadOnlySpan<char> s, out ReadOnlySpan<char> o0, out ReadOnlySpan<char> o1, out ReadOnlySpan<char> o2, out ReadOnlySpan<char> o3)
    {
        int index = s.IndexOf(SeparatorChar);
        if (index < 0)
        {
            o0 = s;
            o1 = o2 = o3 = ReadOnlySpan<char>.Empty;
        }
        else
        {
            o0 = s[0..index];
            if (++index < s.Length)
            {
                if ((index = (s = s[index..]).IndexOf(SeparatorChar)) < 0)
                {
                    o1 = s;
                    o2 = o3 = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    o1 = s[0..index];
                    if (++index < s.Length)
                    {
                        if ((index = (s = s[index..]).IndexOf(SeparatorChar)) < 0)
                        {
                            o2 = s;
                            o3 = ReadOnlySpan<char>.Empty;
                        }
                        else
                        {
                            o2 = s[0..index]; ;
                            if (++index < s.Length)
                            {
                                if ((index = (s = s[index..]).IndexOf(SeparatorChar)) < 0)
                                {
                                    o3 = s;
                                    return o0.Length > 0 && o1.Length > 0 && o2.Length > 0 && o3.Length > 0;
                                }
                                o3 = s[0..index];
                            }
                            else
                                o3 = ReadOnlySpan<char>.Empty;
                        }
                    }
                    else
                        o2 = o3 = ReadOnlySpan<char>.Empty;
                }
            }
            else
                o1 = o2 = o3 = ReadOnlySpan<char>.Empty;
        }
        return false;
    }

    /// <summary>
    /// Tries to parse a span of characters into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
            byte.TryParse(s0, style, provider, out byte o0) && byte.TryParse(s1, style, provider, out byte o1) && byte.TryParse(s2, style, provider, out byte o2) && byte.TryParse(s3, style, provider, out byte o3))
        {
            result = new(o0, o1, o2, o3);
            return true;
        }
        result = MinValue;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = MinValue;
            return false;
        }
        return TryParse(s.AsSpan(), style, provider, out result);
    }

    /// <summary>
    /// Tries to parse a span of characters into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
            byte.TryParse(s0, provider, out byte o0) && byte.TryParse(s1, provider, out byte o1) && byte.TryParse(s2, provider, out byte o2) && byte.TryParse(s3, provider, out byte o3))
        {
            result = new(o0, o1, o2, o3);
            return true;
        }
        result = MinValue;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = MinValue;
            return false;
        }
        return TryParse(s.AsSpan(), provider, out result);
    }

    /// <summary>
    /// Tries to parse a span of characters into a <see cref="IPV4Address"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
            byte.TryParse(s0, style, null, out byte o0) && byte.TryParse(s1, style, null, out byte o1) && byte.TryParse(s2, style, null, out byte o2) && byte.TryParse(s3, style, null, out byte o3))
        {
            result = new(o0, o1, o2, o3);
            return true;
        }
        result = MinValue;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = MinValue;
            return false;
        }
        return TryParse(s.AsSpan(), style, out result);
    }

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (TryGetNumberSpans(s, out ReadOnlySpan<char> s0, out ReadOnlySpan<char> s1, out ReadOnlySpan<char> s2, out ReadOnlySpan<char> s3) &&
            byte.TryParse(s0, out byte o0) && byte.TryParse(s1, out byte o1) && byte.TryParse(s2, out byte o2) && byte.TryParse(s3, out byte o3))
        {
            result = new(o0, o1, o2, o3);
            return true;
        }
        result = MinValue;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out IPV4Address result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = MinValue;
            return false;
        }
        return TryParse(s.AsSpan(), out result);
    }

    #endregion

    #region Explicit Members

    static IPV4Address INumberBase<IPV4Address>.One => _one;

    static int INumberBase<IPV4Address>.Radix => 2;

    static IPV4Address INumberBase<IPV4Address>.Zero => MinValue;

    static IPV4Address IAdditiveIdentity<IPV4Address, IPV4Address>.AdditiveIdentity => MinValue;

    static IPV4Address IMultiplicativeIdentity<IPV4Address, IPV4Address>.MultiplicativeIdentity => _one;

    static IPV4Address INumberBase<IPV4Address>.Abs(IPV4Address value) => value;

    int IBinaryInteger<IPV4Address>.GetByteCount() => 4;

    int IBinaryInteger<IPV4Address>.GetShortestBitLength() => (sizeof(uint) * 8) - BitOperations.LeadingZeroCount(_value);

    TypeCode IConvertible.GetTypeCode() => TypeCode.UInt32;

    static bool INumberBase<IPV4Address>.IsCanonical(IPV4Address value) => true;

    static bool INumberBase<IPV4Address>.IsComplexNumber(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsEvenInteger(IPV4Address value) => (value._value & 1u) == 0u;

    static bool INumberBase<IPV4Address>.IsFinite(IPV4Address value) => true;

    static bool INumberBase<IPV4Address>.IsImaginaryNumber(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsInfinity(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsInteger(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsNaN(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsNegative(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsNegativeInfinity(IPV4Address value) => false;

    static bool INumberBase<IPV4Address>.IsNormal(IPV4Address value) => value._value != 0u;

    static bool INumberBase<IPV4Address>.IsOddInteger(IPV4Address value) => (value._value & 1u) != 0u;

    static bool INumberBase<IPV4Address>.IsPositive(IPV4Address value) => true;

    static bool INumberBase<IPV4Address>.IsPositiveInfinity(IPV4Address value) => false;

    static bool IBinaryNumber<IPV4Address>.IsPow2(IPV4Address value) => uint.IsPow2(value._value);

    static bool INumberBase<IPV4Address>.IsRealNumber(IPV4Address value) => true;

    static bool INumberBase<IPV4Address>.IsSubnormal(IPV4Address value) => false;

    public static bool IsZero(IPV4Address value) => value._value == 0u;

    static IPV4Address IBinaryNumber<IPV4Address>.Log2(IPV4Address value) => new((uint)BitOperations.Log2(value._value));

    public static IPV4Address MaxMagnitude(IPV4Address x, IPV4Address y) => (x._value < y._value) ? y : x;

    static IPV4Address INumberBase<IPV4Address>.MaxMagnitudeNumber(IPV4Address x, IPV4Address y) => (x._value < y._value) ? y : x;

    public static IPV4Address MinMagnitude(IPV4Address x, IPV4Address y) => (x._value < y._value) ? x : y;

    static IPV4Address INumberBase<IPV4Address>.MinMagnitudeNumber(IPV4Address x, IPV4Address y) => (x._value < y._value) ? x : y;

    static IPV4Address IBinaryInteger<IPV4Address>.PopCount(IPV4Address value) => new(uint.PopCount(value._value));

    bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)_value).ToBoolean(provider);

    byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)_value).ToByte(provider);

    char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)_value).ToChar(provider);

    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)_value).ToDateTime(provider);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)_value).ToDecimal(provider);

    double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)_value).ToDouble(provider);

    short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)_value).ToInt16(provider);

    int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)_value).ToInt32(provider);

    long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)_value).ToInt64(provider);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)_value).ToSByte(provider);

    float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)_value).ToSingle(provider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => (format is null && formatProvider is null) ? ToString() :
        $"{_octet0.ToString(format, formatProvider)}.{_octet1.ToString(format, formatProvider)}.{_octet2.ToString(format, formatProvider)}.{_octet3.ToString(format, formatProvider)}";

    string IConvertible.ToString(IFormatProvider? provider) => (provider is null) ? ToString() :
        $"{_octet0.ToString(provider)}.{_octet1.ToString(provider)}.{_octet2.ToString(provider)}.{_octet3.ToString(provider)}";

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
    {
        ArgumentNullException.ThrowIfNull(conversionType);
        if (conversionType.Equals(typeof(uint))) return _value;
        if (conversionType.Equals(typeof(IPV4Address))) return this;
        return ((IConvertible)_value).ToType(conversionType, provider);
    }

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)_value).ToUInt16(provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => _value;

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)_value).ToUInt64(provider);

    static IPV4Address IBinaryInteger<IPV4Address>.TrailingZeroCount(IPV4Address value) => new((uint)BitOperations.TrailingZeroCount(value._value));

    static bool INumberBase<IPV4Address>.TryConvertFromChecked<TOther>(TOther value, out IPV4Address result)
    {
        if (TryConvertFromCheckedToUInt32(value, out uint u))
        {
            result = new(u);
            return true;
        }
        result = MinValue;
        return false;
    }

    static bool INumberBase<IPV4Address>.TryConvertFromSaturating<TOther>(TOther value, out IPV4Address result)
    {
        if (TryConvertFromSaturatingToUInt32(value, out uint u))
        {
            result = new(u);
            return true;
        }
        result = MinValue;
        return false;
    }

    static bool INumberBase<IPV4Address>.TryConvertFromTruncating<TOther>(TOther value, out IPV4Address result)
    {
        if (TryConvertFromTruncatingToUInt32(value, out uint u))
        {
            result = new(u);
            return true;
        }
        result = MinValue;
        return false;
    }

    static bool INumberBase<IPV4Address>.TryConvertToChecked<TOther>(IPV4Address value, [MaybeNullWhen(false)] out TOther result) => TryConvertUInt32ToChecked(value._value, out result);

    static bool INumberBase<IPV4Address>.TryConvertToSaturating<TOther>(IPV4Address value, [MaybeNullWhen(false)] out TOther result) => TryConvertUInt32ToSaturating(value._value, out result);

    static bool INumberBase<IPV4Address>.TryConvertToTruncating<TOther>(IPV4Address value, [MaybeNullWhen(false)] out TOther result) => TryConvertUInt32ToTruncating(value._value, out result);

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        var end = destination.Length;
        if (!_octet0.TryFormat(destination, out charsWritten, format, provider) || charsWritten >= end) return false;
        destination[charsWritten++] = SeparatorChar;
        if (charsWritten == end) return false;
        if (_octet1.TryFormat(destination[charsWritten..], out int cw, format, provider))
        {
            if ((charsWritten += cw) >= end) return false;
            destination[charsWritten++] = SeparatorChar;
            if (charsWritten == end) return false;
            if (_octet2.TryFormat(destination[charsWritten..], out cw, format, provider))
            {
                if ((charsWritten += cw) >= end) return false;
                destination[charsWritten++] = SeparatorChar;
                if (charsWritten == end) return false;
                var result = _octet3.TryFormat(destination[charsWritten..], out cw, format, provider);
                charsWritten += cw;
                return result;
            }
        }
        charsWritten += cw;
        return false;
    }

    static bool IBinaryInteger<IPV4Address>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out IPV4Address value)
    {
        if (TryReadBigEndian(source, isUnsigned, out uint u))
        {
            value = new(u);
            return true;
        }
        value = MinValue;
        return false;
    }

    static bool IBinaryInteger<IPV4Address>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out IPV4Address value)
    {
        if (TryReadLittleEndian(source, isUnsigned, out uint u))
        {
            value = new(u);
            return true;
        }
        value = MinValue;
        return false;
    }

    bool IBinaryInteger<IPV4Address>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteBigEndian(_value, destination, out bytesWritten);

    bool IBinaryInteger<IPV4Address>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteLittleEndian(_value, destination, out bytesWritten);

    #endregion

    #region Operators

    public static IPV4Address operator +(IPV4Address value) => new(+value._value);

    public static IPV4Address operator +(IPV4Address left, IPV4Address right) => new(left._value + right._value);

    public static IPV4Address operator -(IPV4Address value) => new((uint)-value._value);

    public static IPV4Address operator -(IPV4Address left, IPV4Address right) => new(left._value - right._value);

    public static IPV4Address operator ~(IPV4Address value) => new(~value._value);

    public static IPV4Address operator ++(IPV4Address value) => new(value._value + 1u);

    public static IPV4Address operator --(IPV4Address value) => new(value._value - 1u);

    public static IPV4Address operator *(IPV4Address left, IPV4Address right) => new(left._value * right._value);

    public static IPV4Address operator /(IPV4Address left, IPV4Address right) => new(left._value / right._value);

    public static IPV4Address operator %(IPV4Address left, IPV4Address right) => new(left._value % right._value);

    public static IPV4Address operator &(IPV4Address left, IPV4Address right) => new(left._value & right._value);

    public static IPV4Address operator |(IPV4Address left, IPV4Address right) => new(left._value | right._value);

    public static IPV4Address operator ^(IPV4Address left, IPV4Address right) => new(left._value ^ right._value);

    public static IPV4Address operator <<(IPV4Address value, int shiftAmount) => new(value._value << shiftAmount);

    public static IPV4Address operator >>(IPV4Address value, int shiftAmount) => new(value._value >> shiftAmount);

    public static bool operator ==(IPV4Address left, IPV4Address right) => left._value.Equals(right._value);

    public static bool operator !=(IPV4Address left, IPV4Address right) => !left._value.Equals(right._value);

    public static bool operator <(IPV4Address left, IPV4Address right) => left._value < right._value;

    public static bool operator >(IPV4Address left, IPV4Address right) => left._value > right._value;

    public static bool operator <=(IPV4Address left, IPV4Address right) => left._value <= right._value;

    public static bool operator >=(IPV4Address left, IPV4Address right) => left._value >= right._value;

    public static IPV4Address operator >>>(IPV4Address value, int shiftAmount) => new(value._value >>> shiftAmount);

    #endregion
}