namespace BowlingKataAlt
{
    public abstract partial class Frame
    {
        public static Frame CreateEmpty()
        {
            return new Empty();
        }

        private Frame() { }

        public abstract bool IsComplete { get; }
        public abstract Frame AddRoll(Roll roll);
        public abstract int? Score();
    }
}
