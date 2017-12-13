using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.Utilities
{
    public class FrameRateCounter
    {
        private readonly SpriteFont _spriteFont;
        private readonly Stopwatch _stopwatch;
        private float _frameRate;

        public FrameRateCounter()
        {
            _spriteFont = Fonts.Arial;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Draw()
        {
            EvaluateFramerate();
            DrawFrameRate();
            _stopwatch.Restart();
        }

        public void EvaluateFramerate()
        {
            if (_stopwatch.ElapsedTicks != 0)
                _frameRate = (float) Math.Round(10000f / _stopwatch.ElapsedTicks);
        }

        private void DrawFrameRate()
        {
            var fps = $"FPS: {_frameRate}";
            var cameraPos = Handler.Instance.Camera.Position;
            var spriteBatch = MainGame.Instance.SpriteBatch;
            spriteBatch.DrawString(_spriteFont, fps, new Vector2(cameraPos.X + 1, cameraPos.Y + 1), Color.Black);
            spriteBatch.DrawString(_spriteFont, fps, cameraPos, Color.White);
        }
    }
}
