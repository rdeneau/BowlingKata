namespace BowlingKata.Frames
{
    public class FrameFactory
    {
        public IFrame Create(int firstThrow, int nextThrow, int nextNextThrow)
        {
            if (IsStrike(firstThrow))
            {
                return new StrikeFrame(nextThrow, nextNextThrow);
            }

            if (IsSpare(firstThrow, nextThrow))
            {
                return new SpareFrame(nextNextThrow);
            }

            return new NormalFrame(firstThrow, nextThrow);
        }

        private static bool IsStrike(int firstThrow)
        {
            return firstThrow == 10;
        }

        private static bool IsSpare(int firstThrow, int nextThrow)
        {
            return firstThrow + nextThrow == 10;
        }
    }
}
