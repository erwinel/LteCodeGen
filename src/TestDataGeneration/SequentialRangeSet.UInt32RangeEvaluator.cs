namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static readonly UInt32RangeEvaluator UInt32 = UInt32RangeEvaluator.Instance;
    
    public sealed class UInt32RangeEvaluator : IRangeEvaluator<uint>
    {
        public static readonly UInt32RangeEvaluator Instance = new();

        private UInt32RangeEvaluator() { }

        public uint MaxValue => uint.MaxValue;

        public uint MinValue => uint.MinValue;

        public int Compare(uint x, uint y) => x.CompareTo(y);

        public uint GetDecrementedValue(uint value, int count = 1) => value - (uint)count;

        public uint GetIncrementedValue(uint value, int count = 1) => value + (uint)count;

        public ulong GetLongCountInRange(uint firstInclusive, uint lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == uint.MinValue && lastInclusive == uint.MaxValue)) ? 0UL : lastInclusive - firstInclusive + 1UL;

        public IEnumerable<uint> GetSequentialValuesInRange(uint firstInclusive, uint lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(uint value, uint start, uint end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(uint previousValue, uint nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}