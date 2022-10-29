namespace BuddyTween.Algorithms
{
    public static class Elastic
    {
        public static float In(float start, float end, float t)
        {
            end -= start;

            const float t1 = 1f;
            const float t2 = t1 * .3f;
            var t3 = 0f;
            var t4 = 0f;

            if (t == 0)
                return start;

            if ((t /= t1) >= 1)
                return start + end;

            if (t4 == 0f || t4 < Math.Abs(end))
            {
                t4 = end;
                t3 = t2 / 4;
            }
            else
            {
                t3 = (float)(t2 / (2 * Math.PI) * Math.Asin(end / t4));
            }

            return (float)(-(t4 * Math.Pow(2, 10 * (t -= 1))
                        * Math.Sin((t * t1 - t3) * (2 * Math.PI) / t2)) + start);
        }

        public static float Out(float start, float end, float t)
        {
            end -= start;

            const float t1 = 1f;
            const float t2 = t1 * .3f;
            float t3 = 0;
            float t4 = 0;

            if (t == 0)
                return start;

            if ((t /= t1) >= 1)
                return start + end;

            if (t4 == 0f || t4 < Math.Abs(end))
            {
                t4 = end;
                t3 = t2 / 4;
            }
            else
            {
                t3 = (float)(t2 / (2 * Math.PI) * Math.Asin(end / t4));
            }

            return (float)(t4 * Math.Pow(2, -10 * t)
                       * Math.Sin((t * t1 - t3) * (2 * Math.PI) / t2) + end + start);
        }

        public static float InOut(float start, float end, float t)
        {
            end -= start;

            const float t1 = 1f;
            const float t2 = t1 * .3f;
            float t3 = 0;
            float t4 = 0;

            if (t == 0)
                return start;

            if ((t /= t1 / 2) >= 2)
                return start + end;

            if (t4 == 0f || t4 < Math.Abs(end))
            {
                t4 = end;
                t3 = t2 / 4;
            }
            else
            {
                t3 = (float)(t2 / (2 * Math.PI) * Math.Asin(end / t4));
            }

            if (t < 1)
                return (float)(-0.5f * (t4
                                * Math.Pow(2, 10 * (t -= 1))
                                * Math.Sin((t * t1 - t3) * (2 * Math.PI) / t2)) + start);

            return (float)(t4 * Math.Pow(2, -10 * (t -= 1))
                      * Math.Sin((t * t1 - t3) * (2 * Math.PI) / t2) * 0.5f + end + start);
        }
    }
}