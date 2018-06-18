namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private sealed class Empty : Frame
        {
            public override bool IsComplete => false;

            public override Frame AddRoll(Roll roll1) =>
                roll1.IsStrike
                    ? (Frame) new Strike(roll1)
                    : new Incomplete(roll1);

            public override int? Score() => null;
        }
    }
}
