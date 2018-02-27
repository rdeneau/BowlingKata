namespace BowlingKata.Frames
{
    public class SpareFrame : IFrame
    {
        public int ThrowCount => 2;
        public int Score { get; }

        public SpareFrame(int nextPins)
        {
            Score = 10 + nextPins;
        }
    }
}
