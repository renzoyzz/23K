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


        public FrameRateCounter()
        {
            _spriteFont = Fonts.Arial;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Console.WriteLine(gameTime.TotalGameTime);
            float frameRate = 0f;
            if (_stopwatch.ElapsedMilliseconds != 0)
                frameRate = 1000f / _stopwatch.ElapsedMilliseconds;
            var fps = $"fps: {frameRate}";
            spriteBatch.DrawString(_spriteFont, fps, Handler.Instance.Camera.Position, Color.White);
            _stopwatch.Restart();
        }
    }
}
