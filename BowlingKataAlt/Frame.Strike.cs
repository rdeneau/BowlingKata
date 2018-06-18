namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private sealed class Strike : Complete
        {
            private readonly Roll _roll;

            public Strike(Roll roll)
            {
                _roll = roll;
            }

            public override int Score() => Roll.MaxPins + _roll.Next + _roll.Next?.Next;
        }
    }
}
