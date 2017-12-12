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
        private InputHandler inputHandler;
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
            inputHandler = new InputHandler();
            Texture = Textures.Player;
            Velocity = new Velocity(5f, 2f, 2f);
            Size = new Size(50, 50);
        }

        public override void Tick()
        {
            inputHandler.EvaluateInput();
            Velocity.Speed = inputHandler.getForce();
            Velocity.Direction = inputHandler.getDirection();
            Move();
            base.Tick();
        }

        private void Move()
        {
            Position.X += (float)Math.Cos(Velocity.Direction) * (Velocity.Speed);
            Position.Y += (float)Math.Sin(Velocity.Direction) * (Velocity.Speed);
        }
    }
}
