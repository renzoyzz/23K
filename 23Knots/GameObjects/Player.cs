using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _23Knots.ContentLoader;
using _23Knots.GameObjects.Properties;

namespace _23Knots.GameObjects
{
    public class Player : DynamicGameObject
    {
        public Player()
        {
            Initialize();
            SetPosition(Vector2.Zero);
        }

        public Player(Vector2 position)
        {
            Initialize();
            SetPosition(position);
        }

        public Vector2 GetPlayerPosition()
        {
            var currentPosition = new Vector2(Position.X, Position.Y);
            return currentPosition;
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
            Velocity = new Velocity(5f);
            Size = new Size(50, 50);
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
            Velocity.Speed = 0;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Velocity.Speed = Velocity.MaxSpeed;
                directionVector.X++;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                Velocity.Speed = Velocity.MaxSpeed;
                directionVector.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Velocity.Speed = Velocity.MaxSpeed;
                directionVector.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Velocity.Speed = Velocity.MaxSpeed;
                directionVector.Y--;
            }
            if (directionVector == Vector2.Zero)
                Velocity.Speed = 0;
            Velocity.Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
        }

        private void Move()
        {
            Position.X += (float)Math.Cos(Velocity.Direction) * Velocity.Speed;
            Position.Y += (float)Math.Sin(Velocity.Direction) * Velocity.Speed;
        }
    }
}
