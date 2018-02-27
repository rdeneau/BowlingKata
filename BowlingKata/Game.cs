using System.Collections.Generic;
using System.Linq;
using BowlingKata.Frames;

namespace BowlingKata
{
    public class Game
    {
        private const int FrameCount = 10;

        private readonly FrameFactory _frameFactory;
        private int _frameIndex = 0;
        private readonly List<int> _rolls = new List<int>();

        public Game(FrameFactory frameFactory)
        {
            _frameFactory = frameFactory;
        }

        public void Rolls(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score()
        {
            return ComputeFrames().Sum(frame => frame.Score);
        }

        private IEnumerable<IFrame> ComputeFrames()
        {
            var rolls     = GetRollsWithTwoFakeGutterRolls();
            var rollIndex = 0;
            for (var frameIndex = 0; frameIndex < FrameCount; frameIndex++)
            {
                var frame = _frameFactory.Create(
                    rolls[rollIndex],
                    rolls[rollIndex + 1],
                    rolls[rollIndex + 2]);
                rollIndex = rollIndex + frame.ThrowCount;
                yield return frame;
            }
        }

        private List<int> GetRollsWithTwoFakeGutterRolls()
        {
            return new List<int>(_rolls) { 0, 0 };
        }
    }
}
