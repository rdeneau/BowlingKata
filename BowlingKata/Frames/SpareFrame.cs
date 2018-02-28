namespace BowlingKata.Frames
{
    public class SpareFrame : IFrame
    {
        private readonly string _report;

        public int ThrowCount => 2;
        public int Score { get; }

        public SpareFrame(int firstPins, int nextNextPins, bool isLastFrame)
        {
            Score = 10 + nextNextPins;
            _report = PinsPrinter.Print(firstPins) + "/" + (isLastFrame
                                                                ? ("||" + PinsPrinter.Print(nextNextPins))
                                                                : "");
        }

        public string Print()
        {
            return _report;
        }
    }
}
