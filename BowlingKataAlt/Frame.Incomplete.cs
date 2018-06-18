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

            public override Frame AddRoll(Roll roll2) =>
                roll2.IsSpareWith(_roll1)
                    ? (Frame) new Spare(_roll1)
                    : new NoMark(_roll1, roll2);

            public override int? Score() => _roll1.Pins;
        }
    }
}
