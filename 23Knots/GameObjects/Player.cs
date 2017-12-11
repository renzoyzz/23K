using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _23Knots.ContentLoader;

namespace _23Knots.GameObjects
{
    public class Player : GameObject
    {
        private float direction = 0f;
        private float currentSpeed = 0f;

        public Player()
        {
            Speed = 5f;
            Initialize();
            SetPosition(Vector2.Zero);
        }

        public Player(Vector2 position)
        {
            Initialize();
            SetPosition(position);
        }

        public new static Texture2D LoadContent()
        {
            var texture = new Texture2D(MainGame.Instance.Graphics.GraphicsDevice, 1, 1);
            var dataColors = new[]
            {
                Color.Green
            };
            texture.SetData(dataColors);
            return texture;
        }

        private void Initialize()
        {
            Texture = Textures.Player;
        }

        public override void Tick()
        {
            EvaluateInput();
            Move();
            base.Tick();
        }

        private void EvaluateInput()
        {
            var keyboardState = Keyboard.GetState();
            var directionVector = new Vector2();
            currentSpeed = Speed;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                directionVector.X++;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                directionVector.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                directionVector.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                directionVector.Y--;
            }
            else
            {
                currentSpeed = 0;
            }
            direction = (float)Math.Atan2(directionVector.X, -directionVector.Y);
        }

        private void Move()
        {
            Position.X += (float)Math.Cos(direction) * currentSpeed;
            Position.Y += (float)Math.Sin(direction) * currentSpeed;
        }
    }
}
