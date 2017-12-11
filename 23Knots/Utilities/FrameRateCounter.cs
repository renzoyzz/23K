using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.Utilities
{
    public class FrameRateCounter
    {
        private SpriteFont _spriteFont;
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
            spriteBatch.DrawString(_spriteFont, fps, new Vector2(1, 1), Color.Black);
            spriteBatch.DrawString(_spriteFont, fps, new Vector2(0, 0), Color.White);
            _lastDrawGameTime = gameTime.TotalGameTime;
        }
    }
}
