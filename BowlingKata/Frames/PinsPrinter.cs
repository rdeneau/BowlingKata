namespace BowlingKata.Frames
{
    public static class PinsPrinter
    {
        public static string Print(int pins)
        {
            return pins.ToString("0")
                       .Replace("10", "X")
                       .Replace("0", "-");
        }
    }
}
