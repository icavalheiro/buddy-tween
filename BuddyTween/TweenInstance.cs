using BuddyTween.Enums;
using BuddyTween.Algorithms;

namespace BuddyTween
{
    /// <summary>
    /// An disposable, multithread, tween instance
    /// </summary>
    public class TweenInstance
    {
        public event Action? Started;
        public event Action<float>? Updated;
        public event Action<float>? Finished;
        public event Action? Paused;
        public event Action? Resumed;

        public readonly float From;
        public readonly float To;
        public readonly EaseType Type;

        public bool IsFinished { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsPaused { get; private set; }
        public float CurrentValue { get; private set; }

        private readonly int _updateFrameTimeMs;
        private readonly IEnumerator<float> _enum;

        public TweenInstance(float durationSeconds, float from, float to, EaseType type)
        {
            From = from;
            To = to;
            Type = type;
            CurrentValue = from;
            _updateFrameTimeMs = (int)((1 / (float)Tween.UPDATES_PER_SECOND) * 1000);
            var steps = Tween.UPDATES_PER_SECOND * durationSeconds;
            _enum = Tween.CreateEnumerator(from, to, (int)steps, type);
        }

        public void Pause()
        {
            if (IsFinished) return;
            if (!IsStarted) return;

            IsPaused = true;
            Paused?.Invoke();
        }

        public void Resume()
        {
            if (IsFinished) return;
            if (!IsStarted) return;

            IsPaused = false;
            Resumed?.Invoke();
        }

        public TweenInstance Start(Action<float> updateCallback)
        {
            Updated += updateCallback;
            return Start();
        }

        public TweenInstance Start()
        {
            if (IsFinished) return this;
            if (IsStarted) return this;

            IsStarted = true;
            Started?.Invoke();
            Task.Run(Update);

            return this;
        }

        public TweenInstance WhenUpdated(Action<float> callback)
        {
            Updated += callback;
            return this;
        }

        public TweenInstance WhenFinished(Action<float> callback)
        {
            Finished += callback;
            return this;
        }

        public async Task StartAsync(Action<float> updateCallback)
        {
            Updated += updateCallback;
            await StartAsync();
        }

        public async Task StartAsync()
        {
            if (IsFinished) return;
            if (IsStarted) return;

            IsStarted = true;
            Started?.Invoke();
            await Update();
        }

        private async Task Update()
        {
            while (!IsFinished)
            {
                if (IsPaused)
                {
                    await Task.Delay(_updateFrameTimeMs);
                    continue;
                }

                if (!_enum.MoveNext())
                {
                    IsFinished = true;
                    Finished?.Invoke(CurrentValue);
                    continue;
                }

                CurrentValue = _enum.Current;
                Updated?.Invoke(CurrentValue);

                await Task.Delay(_updateFrameTimeMs);
            }
        }
    }
}