using System.Collections.Generic;

namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        public static Frame First()
        {
            return new Empty();
        }

        private Frame() { }

        public abstract bool IsComplete { get; }
        public abstract IEnumerable<Frame> AddRoll(Roll roll);
        public abstract int Score();
    }
}
