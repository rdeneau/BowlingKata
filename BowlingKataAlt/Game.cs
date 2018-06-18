using System.Collections.Generic;
using System.Linq;

namespace BowlingKataAlt
{
    public class Game
    {
        private const int MaxFrames = 10;

        private readonly List<Frame> _frames = new List<Frame>();

        private Frame _currentFrame = Frame.First();
        private Roll  _currentRoll  = Roll.Empty();

        public void AddRoll(int pins)
        {
            UpdateRoll(pins);
            UpdateFrames();
        }

        private void UpdateRoll(int pins)
        {
            var roll = new Roll(pins);
            _currentRoll.Next = roll;
            _currentRoll      = roll;
        }

        private void UpdateFrames()
        {
            var result = _currentFrame.AddRoll(_currentRoll).ToList();
            _frames.AddRange(result.Where(frame => frame.IsComplete).Take(MaxFrames - _frames.Count));
            _currentFrame = result.Single(frame => !frame.IsComplete);
        }

        public int Score() => _currentFrame.Score() + _frames.Sum(frame => frame.Score());
    }
}
