namespace BuddyTween.Algorithms
{
    public static class Spring
    {
        public static float Eval(float start, float end, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            t = (float)((Math.Sin(t * Math.PI * (0.2f + 2.5f * t * t * t))
                * Math.Pow(1f - t, 2.2f) + t) * (1f + (1.2f * (1f - t))));

            return start + (end - start) * t;
        }
    }
}