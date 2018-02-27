using System;
using BowlingKata.Frames;
using NFluent;
using Xunit;

namespace BowlingKata
{
    public class GameTests
    {
        private readonly Game _sut = new Game(new FrameFactory());

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(9)]
        public void Should_Score_Game_With_All_Second_Throws_Missed(int firstPins)
        {
            Repeat(10, Turns(firstPins, 0));

            Check.That(_sut.Score())
                 .Equals(firstPins * 10);
        }

        [Fact]
        public void Should_Score_150_Given_All_Spares_5_5()
        {
            Repeat(10, Turns(5, 5));
            _sut.Rolls(5);

            Check.That(_sut.Score())
                 .Equals(150);
        }

        [Fact]
        public void Should_Score_All_Strikes()
        {
            Repeat(12, Strike());

            Check.That(_sut.Score())
                 .Equals(300);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(9)]
        public void Should_Score_A_Game_With_All_Second_Throws_Missed_But_Last_Being_A_Spare(int firstPins)
        {
            Repeat(9, Turns(firstPins, 0));
            Repeat(1, Turns(5, 5));
            _sut.Rolls(5);

            Check.That(_sut.Score())
                 .Equals(firstPins * 9 + 15);
        }

        private void Repeat(int count, Action<Game> action)
        {
            for (var i = 0; i < count; i++)
            {
                action(_sut);
            }
        }

        private static Action<Game> Strike()
        {
            return sut =>
            {
                sut.Rolls(10);
            };
        }

        private static Action<Game> Turns(int firstPins, int secondPins)
        {
            return sut =>
            {
                sut.Rolls(firstPins);
                sut.Rolls(secondPins);
            };
        }
    }
}
