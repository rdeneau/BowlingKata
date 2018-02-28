namespace BowlingKata.Frames
{
    public class StrikeFrame : IFrame
    {
        private readonly string _report;

        public int ThrowCount => 1;
        public int Score { get; }

        public StrikeFrame(int nextPins, int nextNextPins, bool isLastFrame)
        {
            Score = 10 + nextPins + nextNextPins;
            _report = "X" + (isLastFrame
                                 ? ("||" + PinsPrinter.Print(nextPins) + PinsPrinter.Print(nextNextPins))
                                 : "");
        }

        public string Print()
        {
            return _report;
        }
    }
}
