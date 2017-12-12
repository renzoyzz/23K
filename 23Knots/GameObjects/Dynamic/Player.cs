using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;
using _23Knots.GameObjects.Dynamic.Properties;
using _23Knots.GameObjects.Properties;

namespace _23Knots.GameObjects.Dynamic
{
    public class Player : DynamicGameObject
    {
        private Stats _stats;
        private InputHandler _inputHandler;

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
            _inputHandler = Handler.Instance.InputHandler;
            _stats = new Stats(5f, 5f);
            Texture = Textures.Player;
            Velocity = new Velocity();
            Size = new Size(50, 50);
        }

        public override void Tick()
        {
            _inputHandler.EvaluateInput();
            Velocity.Speed = _inputHandler.Force * _stats.MaxSpeed;
            Velocity.Direction = _inputHandler.Direction;
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
