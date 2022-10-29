using System.Diagnostics.CodeAnalysis;

namespace BuddyTween.Algorithms
{
    public static class Bounce
    {
        
        public static float In(float start, float end, float t)
        {
            end -= start;
            return end - Out(0, end, 1f-t) + start;
        }

        public static float Out(float start, float end, float t)
        {
            t /= 1f;
            end -= start;
            
            if (t < (1 / 2.75f))
            {
                return end * (7.5625f * t * t) + start;
            }
            
            if (t < (2 / 2.75f))
            {
                t -= (1.5f / 2.75f);
                return end * (7.5625f * (t) * t + .75f) + start;
            }
            
            if (t < (2.5f / 2.75f))
            {
                t -= (2.25f / 2.75f);
                return end * (7.5625f * (t) * t + .9375f) + start;
            }
            
            t -= (2.625f / 2.75f);
            return end * (7.5625f * (t) * t + .984375f) + start;
        }        
    }
}