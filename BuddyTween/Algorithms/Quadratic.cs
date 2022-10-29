namespace BuddyTween.Algorithms
{
    public static class Quadratic
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            return end * t * t + start;
        }
        
        public static float Out(float start, float end, float t)
        {
            end -= start;
            return -end * t * (t - 2) + start;
        }
	
        public static float InOut(float start, float end, float t)
        {
            t /= .5f;
            end -= start;
            
            if (t < 1) 
                return end / 2 * t * t + start;
            
            t--;
            
            return -end / 2 * (t * (t - 2) - 1) + start;
        }
    }
}