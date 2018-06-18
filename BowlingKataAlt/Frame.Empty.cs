using System.Collections.Generic;

namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private sealed class Empty : Frame
        {
            public override bool IsComplete => false;

            public override IEnumerable<Frame> AddRoll(Roll roll1)
            {
                if (roll1.IsStrike)
                {
                    yield return new Strike(roll1);
                    yield return new Empty();
                }
                else
                {
                    yield return new Incomplete(roll1);
                }
            }

            public override int Score() => 0;
        }
    }
}
