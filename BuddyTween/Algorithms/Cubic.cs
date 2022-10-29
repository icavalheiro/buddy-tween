namespace BuddyTween.Algorithms
{
    public static class Cubic
    {
        public static float In(float start, float end, float t)
        {
            end -= start;
            return end * t * t * t + start;
        }	
        
        public static float Out(float start, float end, float t)
        {
            t--;
            end -= start;
            return end * (t * t * t + 1) + start;
        }	
        
        public static float InOut(float start, float end, float t)
        {
            t /= .5f;
            end -= start;
            
            if (t < 1) 
                return end / 2 * t * t * t + start;
            
            t -= 2;
            
            return end / 2 * (t * t * t + 2) + start;
        }    
    }
}