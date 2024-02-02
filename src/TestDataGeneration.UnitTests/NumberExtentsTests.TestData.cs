using System.Numerics;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
        class TestData
        {
            public static System.Collections.IEnumerable GetImmediatelyFollowsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B', 'd'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetImmediatelyPrecedesTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'D').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'D').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('C'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'D').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('C', 'E'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'D').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('C', 'E'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'f').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'F').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'C').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'D'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'E').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetGetRelationOfTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'D').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'd').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('D'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0003').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0002').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0001').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MinValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), char.MinValue).Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), char.MaxValue).Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffe').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffd').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffc').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0005').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0004').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0003').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), char.MinValue).Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), char.MaxValue).Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffc').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffb').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffa').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
            }

            public static System.Collections.IEnumerable GetGetRelationToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('d')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0003')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0005')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('f'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0003', '\u0005')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('f', 'h')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'e')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('f', 'h'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0005', '\u0007')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0005', '\u0007'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufff8', '\ufffa'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffb', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff8', '\ufffa')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.FollowsWithGap);
            }

            public static System.Collections.IEnumerable GetReverseTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns(new char[] { 'a' });
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns(new char[] { 'b', 'a' });
                yield return new TestCaseData(new NumberExtents<char>('A', 'F')).Returns(new char[] { 'F', 'E', 'D', 'C', 'B', 'A' });
            }

            public static System.Collections.IEnumerable GetContainsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'C').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0003').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0004').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffb').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffc').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetAsEnumerableTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns(new char[] { 'a' });
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns(new char[] { 'a', 'b' });
                yield return new TestCaseData(new NumberExtents<char>('A', 'F')).Returns(new char[] { 'A', 'B', 'C', 'D', 'E', 'F' });
            }

            public static System.Collections.IEnumerable GetToStringTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns($"{{U+{(int)'a':x4}}}");
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns($"{{U+{(int)'a':x4}..U+{(int)'b':x4}}}");
            }

            public static System.Collections.IEnumerable GetCompareToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('a', 'e')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', '\ufffe')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
            }

            public static System.Collections.IEnumerable GetEqualsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffb', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
            }

            public static System.Collections.IEnumerable GetConstructorTestData()
            {
                yield return new TestCaseData('a', 'a').Returns((First: 'a', Last: 'a', GetCount: new BigInteger(1)));
                yield return new TestCaseData('a', 'b').Returns((First: 'a', Last: 'b', GetCount: new BigInteger(2)));
                yield return new TestCaseData('a', 'z').Returns((First: 'a', Last: 'z', GetCount: new BigInteger(26)));
                yield return new TestCaseData(char.MinValue, '\u0001').Returns((First: char.MinValue, Last: '\u0001', GetCount: new BigInteger(2)))
                    .SetArgDisplayNames("char.MinValue", "'\\u0001'");
                yield return new TestCaseData('\ufffe', char.MaxValue).Returns((First: '\ufffe', Last: char.MaxValue, GetCount: new BigInteger(2)))
                    .SetArgDisplayNames("'\\ufffe'", "char.MaxValue");
                yield return new TestCaseData(char.MinValue, char.MaxValue).Returns((First: char.MinValue, Last: char.MaxValue, GetCount: new BigInteger(char.MaxValue - char.MinValue + 1)))
                    .SetArgDisplayNames("char.MinValue", "char.MaxValue");
            }

            public static System.Collections.IEnumerable GetInvalidExtentsTestData()
            {
                yield return new TestCaseData('b', 'a');
                yield return new TestCaseData(char.MaxValue, '\ufffe').SetArgDisplayNames("char.MaxValue", "'\\ufffe'");
                yield return new TestCaseData('\u0001', char.MinValue).SetArgDisplayNames("'\\u0001'", "char.MinValue");
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'c', extents: new('A')).Returns(true);
                yield return create(value: 'C', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('A')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'E', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'A').Returns(true);
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('C'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'A').Returns(true);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'A').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('A')).Returns(false);
                yield return create(value: 'C', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('A')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'E', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'A').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('C'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'A').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'C').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'A').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'A', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'A', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'C').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('A'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('A', 'C'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'A', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'A', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('A'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('A', 'C'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);

            }

            public static System.Collections.IEnumerable GetIsLessThanTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsLessThanTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'B').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('C'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'D').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'B', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('B'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('B', 'D'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsIncludedInTestData()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'b')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'b')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'b')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'b')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new(char.MinValue, 'e')).Returns(true);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIncludesTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'b'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'b'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'b'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'b'), value: 'd').Returns(false);
                yield return create(extents: new('b', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'e'), value: 'c').Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetWithFirstTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('b'), value: 'a').Returns(new NumberExtents<char>('a', 'b'));
            }

            public static System.Collections.IEnumerable GetWithLastTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'b').Returns(new NumberExtents<char>('a', 'b'));
            }

            public static System.Collections.IEnumerable GetAddFirstTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'z').Returns(new NumberExtents<char>[] { new('a', 'z') });
            }

            public static System.Collections.IEnumerable GetAddFirstTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
            }

            public static System.Collections.IEnumerable GetAddLastTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'z').Returns(new NumberExtents<char>[] { new('a', 'z') });
            }

            public static System.Collections.IEnumerable GetAddLastTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
            }

            public static System.Collections.IEnumerable GetAddPreviousTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: new('a', 'b'), target: new('g', 'h'), after: new('j', 'k'), first: 'd', last: 'e').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
            }

            public static System.Collections.IEnumerable GetAddPreviousTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: new('a'), target: new('e'), after: new('g'), value: 'c').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetAddNextTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: new('a', 'b'), target: new('d', 'e'), after: new('j', 'k'), first: 'g', last: 'h').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
            }

            public static System.Collections.IEnumerable GetAddNextTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: new('a'), target: new('c'), after: new('g'), value: 'e').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetNextTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: new('g'), new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('g') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetPreviousTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: new('a'), new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, first, last, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d'), first: 'c', last: 'e', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandFirstTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char value, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d'), value: 'c', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandLastTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char value, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d'), value: 'e', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('g') });
            }
        }
    }
}