using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.Utilities
{
    public class FrameRateCounter
    {
        private readonly SpriteFont _spriteFont;
        private TimeSpan _lastDrawGameTime;


        public FrameRateCounter()
        {
            _spriteFont = Fonts.Arial;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var elapsedTimeSinceLast = gameTime.TotalGameTime - _lastDrawGameTime;
            float frameRate = 0f;
            if (elapsedTimeSinceLast.Milliseconds != 0)
                frameRate = 1000f / elapsedTimeSinceLast.Milliseconds;
            var fps = $"fps: {frameRate}";
            spriteBatch.DrawString(_spriteFont, fps, Handler.Instance.Camera.Position, Color.White);
            _lastDrawGameTime = gameTime.TotalGameTime;
        }
    }
}
