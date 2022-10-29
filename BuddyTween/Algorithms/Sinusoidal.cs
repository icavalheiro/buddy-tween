namespace BuddyTween.Algorithms
{
    public static class Sinusoidal
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            return (float)(-end * Math.Cos(t / 1 * (Math.PI / 2f)) + end + start);
        }

        public static float Out(float start, float end, float t)
        {
            end -= start;
            return (float)(end * Math.Sin(t / 1 * (Math.PI / 2f)) + start);
        }

        public static float InOut(float start, float end, float t)
        {
            end -= start;
            return (float)(-end / 2f * (Math.Cos(Math.PI * t) - 1) + start);
        }
    }
}