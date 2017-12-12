using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _23Knots.ContentLoader;
using _23Knots.GameObjects.Properties;

namespace _23Knots.GameObjects
{
    public class Player : GameObject
    {
        private float _direction = 0f;
        private float _currentSpeed = 0f;
        protected new Size Size = new Size(50, 50);

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
            _currentSpeed = 0;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _currentSpeed = Speed;
                directionVector.X++;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _currentSpeed = Speed;
                directionVector.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _currentSpeed = Speed;
                directionVector.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _currentSpeed = Speed;
                directionVector.Y--;
            }
            if (directionVector == Vector2.Zero)
                _currentSpeed = 0;
            _direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
        }

        private void Move()
        {
            Position.X += (float)Math.Cos(_direction) * _currentSpeed;
            Position.Y += (float)Math.Sin(_direction) * _currentSpeed;
        }
    }
}
