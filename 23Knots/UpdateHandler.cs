using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace _23Knots
{
    public class UpdateHandler
    {
        private Stopwatch _updateStopwatch;
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

        public void Update()
        {
            if (!ReadyToUpdate())
                return;
            _updateStopwatch.Restart();
            Handler.Instance.Tick();
        }

        public void Draw()
        {
            TimeCoefficient = (float)_updateStopwatch.Elapsed.TotalMilliseconds / (float)MainGame.Instance.TargetElapsedTime.TotalMilliseconds;
        }

        private bool ReadyToUpdate()
        {
            if (_updateStopwatch == null)
                _updateStopwatch = Stopwatch.StartNew();
            return _updateStopwatch.Elapsed >= MainGame.Instance.TargetElapsedTime;
        }
    }
}
