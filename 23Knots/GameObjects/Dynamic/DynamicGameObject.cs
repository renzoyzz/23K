﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.GameObjects.Dynamic.Properties;

namespace _23Knots.GameObjects.Dynamic
{
    public abstract class DynamicGameObject : GameObject
    {
        protected Vector2 PreviousPosition;
        protected Velocity Velocity;

        public override void Draw(SpriteBatch spriteBatch)
        {
            var drawSize = new Rectangle(0, 0, Size.Width, Size.Height);
            var updateTimeCoefficient = Handler.Instance.UpdateTimeCoefficient;
            var drawPosition = Vector2.Lerp(PreviousPosition, Position, updateTimeCoefficient);
            spriteBatch.Draw(Texture, drawPosition, drawSize, Color.White);
        }

        public override void Tick()
        {
            PreviousPosition = Position;
        }
    }
}
