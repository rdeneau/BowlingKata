namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private class Spare : Complete
        {
            private readonly Roll _roll1;

            public Spare(Roll roll1)
            {
                _roll1 = roll1;
            }

            public override int Score() => Roll.MaxPins + _roll1.Next.Next;
        }
    }
}
