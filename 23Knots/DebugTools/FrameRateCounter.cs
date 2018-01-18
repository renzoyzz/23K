using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.DebugTools
{
    public class FrameRateCounter
    {
        private readonly SpriteFont _spriteFont;
        private long _fps;
        private readonly Stopwatch _timer = new Stopwatch();

        public FrameRateCounter()
        {
            _spriteFont = Fonts.Arial;
            _timer.Start();
        }

        public void Draw()
        {
            // ReSharper disable once PossibleLossOfFraction
            _fps = TimeSpan.TicksPerSecond / _timer.ElapsedTicks;
            var fps = $"FPS: {_fps}";
            var cameraPos = Handler.Instance.Camera.DrawPosition;
            var spriteBatch = MainGame.Instance.SpriteBatch;
            spriteBatch.DrawString(_spriteFont, fps, new Vector2(cameraPos.X + 1, cameraPos.Y + 1), Color.Black);
            spriteBatch.DrawString(_spriteFont, fps, cameraPos, Color.White);
            _timer.Restart();
        }
    }
}
