namespace BuddyTween.Algorithms
{
    public static class Linear
    {
        public static float Eval(float start, float end, float t)
        {
            return start * (1 - t) + end * t;
        }
    }
}