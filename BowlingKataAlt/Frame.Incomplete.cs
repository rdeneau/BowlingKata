using System.Collections.Generic;

namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private sealed class Incomplete : Frame
        {
            private readonly Roll _roll1;

            public Incomplete(Roll roll1)
            {
                _roll1 = roll1;
            }

            public override bool IsComplete => false;

            public override IEnumerable<Frame> AddRoll(Roll roll2)
            {
                if (roll2.IsSpareWith(_roll1))
                {
                    yield return new Spare(_roll1);
                }
                else
                {
                    yield return new NoMark(_roll1, roll2);
                }

                yield return new Empty();
            }

            public override int Score() => _roll1.Pins;
        }
    }
}
