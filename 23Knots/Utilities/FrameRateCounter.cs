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
        private double _frameRate;
        private int _frames;

        public FrameRateCounter()
        {
            _spriteFont = Fonts.Arial;
            _frames = 0;
        }

        public void Update()
        {
            if (_frames == 0) return;
            var ticksPerSecond = MainGame.Instance.UpdateHandler.TargetTicksPerSecond;
            _frameRate = Math.Round((double) (ticksPerSecond * _frames));
            _frames = 0;
        }

        public void Draw()
        {
            _frames++;
            var fps = $"FPS: {_frameRate}";
            var cameraPos = Handler.Instance.Camera.ViewPosition;
            var spriteBatch = MainGame.Instance.SpriteBatch;
            spriteBatch.DrawString(_spriteFont, fps, new Vector2(cameraPos.X + 1, cameraPos.Y + 1), Color.Black);
            spriteBatch.DrawString(_spriteFont, fps, cameraPos, Color.White);
        }
    }
}
