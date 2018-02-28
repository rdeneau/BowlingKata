namespace BowlingKata.Frames
{
    public class FrameFactory
    {
        public IFrame Create(int firstPins, int nextPins, int nextNextPins, bool isLastFrame)
        {
            if (IsStrike(firstPins))
            {
                return new StrikeFrame(nextPins, nextNextPins, isLastFrame);
            }

            if (IsSpare(firstPins, nextPins))
            {
                return new SpareFrame(firstPins, nextNextPins, isLastFrame);
            }

            return new NormalFrame(firstPins, nextPins);
        }

        private static bool IsStrike(int firstPins)
        {
            return firstPins == 10;
        }

        private static bool IsSpare(int firstPins, int nextPins)
        {
            return firstPins + nextPins == 10;
        }
    }
}
