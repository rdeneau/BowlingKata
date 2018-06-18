using System.Collections.Generic;

namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private abstract class Complete : Frame
        {
            public override bool IsComplete => true;

            public override IEnumerable<Frame> AddRoll(Roll roll)
            {
                yield break;
            }
        }
    }
}
