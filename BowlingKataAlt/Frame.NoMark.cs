namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        private class NoMark : Complete
        {
            private readonly Roll _roll1;
            private readonly Roll _roll2;

            public NoMark(Roll roll1, Roll roll2)
            {
                _roll1 = roll1;
                _roll2 = roll2;
            }

            public override int? Score() => _roll1 + _roll2;
        }
    }
}
