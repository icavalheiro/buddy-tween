using BuddyTween.Enums;
using BuddyTween.Algorithms;

namespace BuddyTween
{
    public static class Tween
    {
        public static int UPDATES_PER_SECOND = 80;

        public static TweenInstance Create(float durationSeconds, float from = 0, float to = 1, EaseType type = EaseType.CubicInOut)
        {
            return new TweenInstance(durationSeconds, from, to, type);
        }

        public static IEnumerator<float> CreateEnumerator(int steps, EaseType type = EaseType.CubicOut)
        {
            return CreateEnumerator(0, 1, steps, type);
        }

        public static IEnumerator<float> CreateEnumerator(float from, float to, int steps, EaseType type = EaseType.CubicOut)
        {
            var stepIncrease = 1f / steps;
            float t;
            var algorithm = AlgorithmSelector.FromType(type);

            if (algorithm is null)
            {
                throw new Exception($"{type} does not have an algorithm implemented yet.");
            }

            for (var i = 0; i < steps; i++)
            {
                t = i * stepIncrease;

                yield return algorithm(from, to, t);
            }
        }

    }
}