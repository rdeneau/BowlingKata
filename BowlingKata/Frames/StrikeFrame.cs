namespace BowlingKata.Frames
{
    public class StrikeFrame : IFrame
    {
        public int ThrowCount => 1;
        public int Score { get; }

        public StrikeFrame(int nextPins, int nextNextPins)
        {
            Score = 10 + nextPins + nextNextPins;
        }
    }
}
