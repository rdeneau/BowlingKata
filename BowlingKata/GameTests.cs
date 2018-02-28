using System;
using BowlingKata.Frames;
using NFluent;
using Xunit;

namespace BowlingKata
{
    public class GameTests
    {
        private readonly Game _sut = new Game(new FrameFactory());

        [Fact]
        public void Should_Print_Gutter_Game()
        {
            Repeat(10, Turns(0, 0));

            Check.That(_sut.Print())
                 .Equals("--|--|--|--|--|--|--|--|--|--");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void Should_Print_Game_With_All_Second_Throws_Missed(int firstPins)
        {
            Repeat(10, Turns(firstPins, 0));

            var expected = "i-|i-|i-|i-|i-|i-|i-|i-|i-|i-".Replace("i", firstPins.ToString("0"));
            Check.That(_sut.Print())
                 .Equals(expected);
        }

        [Fact]
        public void Should_Print_Custom_Game_Without_Final_Strike()
        {
            Play(Turns(0, 0),
                 Turns(1, 0),
                 Turns(0, 2),
                 Turns(3, 3),
                 Turns(4, 1),
                 Turns(5, 5),
                 Turns(6, 4),
                 Strike(),
                 Turns(8, 0),
                 Turns(0, 9));

            Check.That(_sut.Print())
                 .Equals("--|1-|-2|33|41|5/|6/|X|8-|-9");
        }

        [Fact]
        public void Should_Print_Custom_Game_With_Final_Strike()
        {
            Play(Turns(0, 0),
                 Turns(1, 0),
                 Turns(0, 2),
                 Turns(3, 3),
                 Turns(4, 1),
                 Turns(5, 5),
                 Turns(6, 4),
                 Strike(),
                 Turns(0, 0),
                 Strike(),
                 Strike(),
                 Rolls(5));

            Check.That(_sut.Print())
                 .Equals("--|1-|-2|33|41|5/|6/|X|--|X||X5");
        }

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
            Play(Rolls(5));

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
            Play(Turns(5, 5),
                 Rolls(5));

            Check.That(_sut.Score())
                 .Equals(firstPins * 9 + 15);
        }

        private void Play(params Action<Game>[] actions)
        {
            foreach (var action in actions)
            {
                action(_sut);
            }
        }

        private void Repeat(int count, Action<Game> action)
        {
            for (var i = 0; i < count; i++)
            {
                action(_sut);
            }
        }

        private static Action<Game> Rolls(int pins) => sut => sut.Rolls(pins);

        private static Action<Game> Strike() => Rolls(10);

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
