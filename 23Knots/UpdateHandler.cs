using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace _23Knots
{
    public class UpdateHandler
    {
        private readonly Stopwatch _updateStopwatch = new Stopwatch();
        private bool _initialized;
        public float TimeCoefficient { get; set; }
        private int _targetTicksPerSecond;

        public int TargetTicksPerSecond
        {
            get => _targetTicksPerSecond;
            set
            {
                _targetTicksPerSecond = value;
                MainGame.Instance.TargetElapsedTime = TimeSpan.FromSeconds(1f / value);
            }
        }

        public UpdateHandler(int targetTicksPerSecond)
        {
            MainGame.Instance.IsFixedTimeStep = false;
            TargetTicksPerSecond = targetTicksPerSecond;
        }

        public void Call()
        {
            if (!IsTargetTimeElapsed())
                return;
            Handler.Instance.Tick();
            _updateStopwatch.Restart();
        }

        public void DrawCalled()
        {
            TimeCoefficient = (float)_updateStopwatch.Elapsed.TotalMilliseconds / (float)MainGame.Instance.TargetElapsedTime.TotalMilliseconds;
        }

        private bool IsTargetTimeElapsed()
        {
            if (!_initialized)
            {
                _updateStopwatch.Start();
                _initialized = true;
            }
            return !IsElapsedTimeLessThanTargetTime();
        }

        private bool IsElapsedTimeLessThanTargetTime()
        {
            return _updateStopwatch.Elapsed < MainGame.Instance.TargetElapsedTime;
        }
    }

}
