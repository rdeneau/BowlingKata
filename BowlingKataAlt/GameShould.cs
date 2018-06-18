using FluentAssertions;
using Xunit;

namespace BowlingKataAlt
{
    public class GameShould
    {
        private readonly Game _sut = new Game();

        [Fact]
        public void Score_Zero_At_First()
        {
            _sut.Score()
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void Score_Pending_After_One_Roll(int pins)
        {
            AddRolls(pins);

            _sut.Score()
                .Should()
                .Be(pins);
        }

        [Fact]
        public void Score_Pins_Down_After_Two_Little_Rolls()
        {
            AddRolls(2, 4);

            _sut.Score()
                .Should()
                .Be(2 + 4);
        }

        [Fact]
        public void Score_First_Spare()
        {
            AddRolls(9, 1, 8);

            _sut.Score()
                .Should()
                .Be((10 + 8) + 8);
        }

        [Fact]
        public void Score_First_Strike()
        {
            AddRolls(10, 6, 2);

            _sut.Score()
                .Should()
                .Be((10 + 6 + 2) + 6 + 2);
        }

        [Fact]
        public void Score_All_Strikes()
        {
            AddRolls(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10);

            _sut.Score()
                .Should()
                .Be(300);
        }

        [Fact]
        public void Score_133()
        {
            ScoreShouldBeAfterThisFrame(5,  1, 4);
            ScoreShouldBeAfterThisFrame(14, 4, 5);
            ScoreShouldBeAfterThisSpare(29, 6);
            ScoreShouldBeAfterThisSpare(49, 5);
            ScoreShouldBeAfterThisStrike(60);
            ScoreShouldBeAfterThisFrame(61, 0, 1);
            ScoreShouldBeAfterThisSpare(77, 7);
            ScoreShouldBeAfterThisSpare(97, 6);
            ScoreShouldBeAfterThisStrike(117);
            ScoreShouldBeAfterThisFrame(133, 2, 8, 6);
        }

        private void AddRolls(params int[] rolls)
        {
            foreach (var roll in rolls)
            {
                _sut.AddRoll(roll);
            }
        }

        private void ScoreShouldBeAfterThisFrame(int expectedScore, params int[] rolls)
        {
            AddRolls(rolls);

            _sut.Score()
                .Should()
                .Be(expectedScore);
        }

        private void ScoreShouldBeAfterThisSpare(int expectedScore, int roll1)
        {
            ScoreShouldBeAfterThisFrame(expectedScore, roll1, 10 - roll1);
        }

        private void ScoreShouldBeAfterThisStrike(int expectedScore)
        {
            ScoreShouldBeAfterThisFrame(expectedScore, 10);
        }
    }
}
