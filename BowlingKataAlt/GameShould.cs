using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BowlingKataAlt
{
    public class GameShould
    {
        private readonly List<int> _expectedScoresUpToFrame = new List<int>();
        private readonly Game _sut = new Game();

        [Fact]
        public void Score_Zero_At_First()
        {
            ScoreShouldBe(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void Score_Pending_After_One_Roll(int pins)
        {
            AddRolls(pins);
            ScoreShouldBe(pins);
        }

        [Fact]
        public void Score_Pins_Down_After_Two_Little_Rolls()
        {
            AddRolls(2, 4);
            ScoreShouldBe(2 + 4);
        }

        [Fact]
        public void Score_First_Spare()
        {
            AddRolls(9, 1, 8);
            ScoreShouldBe((10 + 8) + 8);
        }

        [Fact]
        public void Score_First_Strike()
        {
            AddRolls(10, 6, 2);
            ScoreShouldBe((10 + 6 + 2) + 6 + 2);
        }

        [Fact]
        public void Score_All_Strikes()
        {
            AddRolls(10, 10, 10, 10, 10);
            AddRolls(10, 10, 10, 10, 10);
            AddRolls(10, 10);
            ScoreShouldBe(300);
        }

        [Fact]
        public void Score_133()
        {
            ScoreShouldBeUpToThisFrame(5, 1, 4);
            ScoreShouldBeUpToThisFrame(14, 4, 5);
            ScoreShouldBeUpToThisSpare(29, 6);
            ScoreShouldBeUpToThisSpare(49, 5);
            ScoreShouldBeUpToThisStrike(60);
            ScoreShouldBeUpToThisFrame(61, 0, 1);
            ScoreShouldBeUpToThisSpare(77, 7);
            ScoreShouldBeUpToThisSpare(97, 6);
            ScoreShouldBeUpToThisStrike(117);
            ScoreShouldBeUpToThisFrame(133, 2, 8, 6);
            VerifyExpectedScoresUpToFrame();
        }

        private void AddRolls(params int[] rolls)
        {
            foreach (var roll in rolls)
            {
                _sut.AddRoll(roll);
            }
        }

        private void ScoreShouldBe(int expectedScore)
        {
            _sut.Score()
                .Should()
                .Be(expectedScore);
        }

        private void ScoreShouldBeUpToThisFrame(int expectedScore, params int[] rolls)
        {
            AddRolls(rolls);
            _expectedScoresUpToFrame.Add(expectedScore);
        }

        private void ScoreShouldBeUpToThisSpare(int expectedScore, int roll1)
        {
            ScoreShouldBeUpToThisFrame(expectedScore, roll1, 10 - roll1);
        }

        private void ScoreShouldBeUpToThisStrike(int expectedScore)
        {
            ScoreShouldBeUpToThisFrame(expectedScore, 10);
        }

        private void VerifyExpectedScoresUpToFrame()
        {
            for (var i = 0; i < 10; i++)
            {
                _sut.ScoreUpToFrame(i)
                    .Should()
                    .Be(_expectedScoresUpToFrame[i]);
            }
        }
    }
}
