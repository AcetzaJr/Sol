namespace Muza
{
    public static class Math
    {
        public static int PMod(int n, int m)
        {
            return n < 0 ? (n % m + m) % m : n % m;
        }

        public static float ToDB(float amplitude)
        {
            return 10.0f * MathF.Log10(amplitude);
        }

        public static float FromDB(float db)
        {
            return MathF.Pow(10.0f, db / 10.0f);
        }

        public static float Clamp(float value, float low, float high)
        {
            return value < low ? low : value > high ? high : value;
        }
    }
}