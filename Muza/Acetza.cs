namespace Muza
{
    internal static class Acetza
    {
        private static readonly float[] rations =
        [
            (float)1 / 1,
        (float)256 / 243,
        (float)9 / 8,
        (float)32 / 27,
        (float)81 / 64,
        (float)4 / 3,
        Tempered.Frequency(6, baseFrequency: 1.0f),
        (float)3 / 2,
        (float)128 / 81,
        (float)27 / 16,
        (float)16 / 9,
        (float)243 / 128
        ];
        public static float baseFrequency = Constants.BaseFrequency;
        public static float Ration(int note)
        {
            return rations[Math.PMod(note, 12)];
        }
        public static float Power(int note)
        {
            return MathF.Pow(2.0f, note < note - 12 ? 0 : note / 12);
        }
        public static float Frequency(int note)
        {
            return baseFrequency * Ration(note) * Power(note);
        }
    }
}