namespace BuddyTween.Algorithms
{
    public static class Exponential
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            return (float)(end * Math.Pow(2, 10 * (t / 1 - 1)) + start);
        }

        public static float Out(float start, float end, float t)
        {
            end -= start;
            return (float)(end * (-Math.Pow(2, -10 * t / 1) + 1) + start);
        }

        public static float InOut(float start, float end, float t)
        {
            t /= .5f;
            end -= start;

            if (t < 1)
                return (float)(end / 2 * Math.Pow(2, 10 * (t - 1)) + start);

            t--;
            return (float)(end / 2 * (-Math.Pow(2, -10 * t) + 2) + start);
        }
    }
}