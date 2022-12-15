using BuddyTween.Enums;
using BuddyTween.Algorithms;

namespace BuddyTween
{
    public static class Tween
    {
        public static int UPDATES_PER_SECOND = 80;

        public static TweenInstance Create(float durationSeconds, Func<float, float> customEaseFunction, float from = 0, float to = 1)
        {
            return new TweenInstance(durationSeconds, customEaseFunction, from, to);
        }

        public static TweenInstance Create(float durationSeconds, EaseType type = EaseType.CubicInOut, float from = 0, float to = 1)
        {
            return new TweenInstance(durationSeconds, type, from, to);
        }

        public static IEnumerator<float> CreateEnumerator(int steps, EaseType type = EaseType.CubicOut)
        {
            return CreateEnumerator(0, 1, steps, type);
        }

        public static IEnumerator<float> CreateEnumerator(float from, float to, int steps, Func<float, float> customEaseFunction)
        {
            var stepIncrease = 1f / steps;
            float t;

            float difference = to - from;

            for (var i = 0; i < steps - 1; i++)
            {
                t = i * stepIncrease;

                var delta = customEaseFunction(t);

                yield return from + (difference * delta);
            }

            yield return to;
        }

        public static IEnumerator<float> CreateEnumerator(float from, float to, int steps, EaseType type = EaseType.CubicOut)
        {
            var algorithm = AlgorithmSelector.FromType(type);

            if (algorithm is null)
            {
                throw new Exception($"{type} does not have an algorithm implemented.");
            }

            var easeFunction = (float t) =>
            {
                return algorithm(0, 1, t);
            };

            return CreateEnumerator(from, to, steps, easeFunction);
        }

    }
}