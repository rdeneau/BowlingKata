using System.Linq;

namespace BowlingKataAlt
{
    public class Game
    {
        private const int MaxFrames = 10;

        private readonly Frame[] _frames = Enumerable.Range(1, MaxFrames)
                                                     .Select(_ => Frame.CreateEmpty())
                                                     .ToArray();

        private int _currentFrameIndex;
        private Roll _currentRoll = Roll.Empty();

        private Frame CurrentFrame
        {
            get => _frames[_currentFrameIndex];
            set
            {
                _frames[_currentFrameIndex] = value;
                if (value.IsComplete &&
                    _currentFrameIndex < MaxFrames - 1)
                {
                    _currentFrameIndex++;
                }
            }
        }

        public void AddRoll(int pins)
        {
            UpdateRoll(new Roll(pins));
            UpdateFrames();
        }

        private void UpdateRoll(Roll nextRoll)
        {
            _currentRoll.Next = nextRoll;
            _currentRoll      = nextRoll;
        }

        private void UpdateFrames()
        {
            CurrentFrame = CurrentFrame.AddRoll(_currentRoll);
        }

        public int ScoreUpToFrame(int frameIndex) =>
            _frames.Take(frameIndex + 1)
                   .Sum(frame => frame.Score() ?? 0);

        public int Score() => ScoreUpToFrame(MaxFrames);
    }
}
