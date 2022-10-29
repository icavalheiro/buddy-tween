namespace BuddyTween.Algorithms
{
    public static class Circular
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            return (float)(-end * (Math.Sqrt(1 - t * t) - 1) + start);
        }

        public static float Out(float start, float end, float t)
        {
            t--;
            end -= start;
            return (float)(end * Math.Sqrt(1 - t * t) + start);
        }

        public static float InOut(float start, float end, float t)
        {
            t /= .5f;
            end -= start;

            if (t < 1)
                return (float)(-end / 2 * (Math.Sqrt(1 - t * t) - 1) + start);

            t -= 2;

            return (float)(end / 2 * (Math.Sqrt(1 - t * t) + 1) + start);
        }
    }
}