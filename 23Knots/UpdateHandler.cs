﻿using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _23Knots
{
    public class UpdateHandler
    {
        private readonly Stopwatch _updateStopwatch = new Stopwatch();
        private bool _initialized;
        public float TimeCoefficient => (float)_updateStopwatch.Elapsed.TotalMilliseconds / (float)MainGame.Instance.TargetElapsedTime.TotalMilliseconds;
        public int TargetTicksPerSecond { get; }

        public UpdateHandler(int targetTicksPerSecond)
        {
            TargetTicksPerSecond = targetTicksPerSecond;
            MainGame.Instance.IsFixedTimeStep = false;
            MainGame.Instance.TargetElapsedTime = TimeSpan.FromSeconds(1f / targetTicksPerSecond);
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

        public void Call(GameTime gameTime)
        {
            if (!IsTargetTimeElapsed())
                return;
            Handler.Instance.Tick(gameTime);
            _updateStopwatch.Restart();

        }

        private bool IsElapsedTimeLessThanTargetTime()
        {
            return _updateStopwatch.Elapsed < MainGame.Instance.TargetElapsedTime;
        }
    }

}