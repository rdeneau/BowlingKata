using System;

namespace BowlingKataAlt
{
    public class Roll
    {
        public const int MaxPins = 10;

        public int Pins { get; }

        public static Roll Empty() => new Roll(0);

        public Roll(int pins)
        {
            if (pins < 0)
            {
                throw new ArgumentException($"Expecting roll (${pins}) >= 0");
            }

            if (pins > MaxPins)
            {
                throw new ArgumentException($"Expecting roll (${pins}) <= ${MaxPins}");
            }

            Pins = pins;
        }

        public bool IsStrike => Pins == MaxPins;
        public Roll Next { get; set; }

        public bool IsSpareWith(Roll other)
        {
            AssertCanBeAfter(other);
            return Pins + other.Pins == MaxPins;
        }

        private void AssertCanBeAfter(Roll other)
        {
            var max = MaxPins - other.Pins;
            if (Pins > max)
            {
                throw new ArgumentException($"Expecting roll (${Pins}) <= ${max}");
            }
        }

        public static implicit operator int(Roll roll) => roll?.Pins ?? 0;
    }
}
