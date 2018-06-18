namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private abstract class Complete : Frame
        {
            public override bool IsComplete => true;

            public override Frame AddRoll(Roll roll) => this;
        }
    }
}
