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
        public void Should_Score_Spare_And_Strike_Summing_All_Three_Throws(int firstPins, int nextPins, int nextNextPins)
        {
            var sut = CreateFrame(firstPins, nextPins, nextNextPins);
            Check.That(sut.Score)
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
        public void Should_Score_NormalFrame_Summing_First_Two_Throws(int firstPins, int nextPins, int nextNextPins)
        {
            var sut = CreateFrame(firstPins, nextPins, nextNextPins);
            Check.That(sut.Score)
                 .Equals(firstPins + nextPins);
        }

        [Fact]
        public void Should_Print_NormalFrame_Without_Miss()
        {
            var sut = CreateFrame(1, 1, -1);
            Check.That(sut.Print())
                 .Equals("11");
        }

        [Fact]
        public void Should_Print_NormalFrame_With_One_Miss()
        {
            var sut = CreateFrame(1, 0, -1);
            Check.That(sut.Print())
                 .Equals("1-");
        }

        [Fact]
        public void Should_Print_Strike()
        {
            var sut = CreateFrame(10, -1, -1);
            Check.That(sut.Print())
                 .Equals("X");
        }

        [Fact]
        public void Should_Print_Spare()
        {
            var sut = CreateFrame(9, 1, -1);
            Check.That(sut.Print())
                 .Equals("9/");
        }

        [Theory]
        [InlineData(9, 2, "9/||2")]
        [InlineData(8, 0, "8/||-")]
        [InlineData(0, 10, "-/||X")]
        public void Should_Print_Last_Spare(int firstPins, int nextNextPins, string expected)
        {
            var sut = CreateLastFrame(firstPins, 10 - firstPins, nextNextPins);
            Check.That(sut.Print())
                 .Equals(expected);
        }

        [Theory]
        [InlineData(9, 2,  "X||92")]
        [InlineData(8, 0,  "X||8-")]
        [InlineData(0, 0, "X||--")]
        [InlineData(0, 10, "X||-X")]
        [InlineData(10, 10, "X||XX")]
        public void Should_Print_Last_Strike(int nextPins, int nextNextPins, string expected)
        {
            var sut = CreateLastFrame(10, nextPins, nextNextPins);
            Check.That(sut.Print())
                 .Equals(expected);
        }

        private static IFrame CreateFrame(int firstPins, int nextPins, int nextNextPins)
        {
            return new FrameFactory().Create(firstPins, nextPins, nextNextPins, false);
        }

        private static IFrame CreateLastFrame(int firstPins, int nextPins, int nextNextPins)
        {
            return new FrameFactory().Create(firstPins, nextPins, nextNextPins, true);
        }
    }
}
