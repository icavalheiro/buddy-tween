namespace BuddyTween.Algorithms
{
    public static class Back
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            const float s = 1.70158f;
            return end * (t) * t * ((s + 1) * t - s) + start;
        }
        
        public static float Out(float start, float end, float t)
        {
            const float temp = 1.70158f;
            end -= start;
            t --;
            return end * ((t) * t * ((temp + 1) * t + temp) + 1) + start;
        }
        
        public static float InOut(float start, float end, float t)
        {
            var t1 = 1.70158f;
            end -= start;
            t /= .5f;
            
            if (t < 1)
            {
                t1 *= (1.525f);
                return end / 2f * (t * t * (((t1) + 1) * t - t1)) + start;
            }
            
            t -= 2;
            t1 *= (1.525f);
            return end / 2f * ((t) * t * (((t1) + 1) * t + t1) + 2) + start;
        }
    }
}