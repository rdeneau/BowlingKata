using NFluent;
using Xunit;

namespace BowlingKata.Frames
{
    public class FrameTests
    {
        [Theory]
        [InlineData(9, 1, 0)]
        [InlineData(9, 1, 8)]
        [InlineData(9, 1, 9)]
        [InlineData(9, 1, 10)]
        [InlineData(10, 1, 0)]
        [InlineData(10, 9, 0)]
        [InlineData(10, 2, 8)]
        public void SpareFrame_And_StrikeFrame_Should_Score_Three_Rolls(int firstPins, int nextPins, int nextNextPins)
        {
            var frame = new FrameFactory().Create(firstPins, nextPins, nextNextPins);
            Check.That(frame.Score)
                 .Equals(firstPins + nextPins + nextNextPins);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 9, 0)]
        [InlineData(9, 0, 0)]
        [InlineData(8, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 9, 1)]
        [InlineData(9, 0, 1)]
        [InlineData(8, 1, 1)]
        public void NormalFrame_Should_Score_Summing_First_Two_Rolls(int firstPins, int nextPins, int nextNextPins)
        {
            var frame = new FrameFactory().Create(firstPins, nextPins, nextNextPins);
            Check.That(frame.Score)
                 .Equals(firstPins + nextPins);
        }

    }
}
