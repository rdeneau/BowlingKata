namespace BowlingKata.Frames
{
    public class NormalFrame : IFrame
    {
        private readonly string _report;

        public int ThrowCount => 2;
        public int Score { get; }

        public NormalFrame(int firstPins, int nextPins)
        {
            Score = firstPins + nextPins;
            _report = PinsPrinter.Print(firstPins) +
                      PinsPrinter.Print(nextPins);
        }

        public string Print()
        {
            return _report;
        }
    }
}
