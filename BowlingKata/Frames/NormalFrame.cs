namespace BowlingKata.Frames
{
    public class NormalFrame : IFrame
    {
        public int ThrowCount => 2;
        public int Score { get; }

        public NormalFrame(int firstPins, int nextPins)
        {
            Score = firstPins + nextPins;
        }
    }
}
