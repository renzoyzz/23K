﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;
using _23Knots.GameObjects.Dynamic.Properties;
using _23Knots.GameObjects.Properties;
using _23Knots.Input;

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
            _stats = new Stats(.2f, 10f);
            Texture = Textures.Player;
            Velocity = new Velocity();
            Size = new Size(50, 50);
        }

        public override void Tick()
        {
            ApplyInput();
            base.Tick();
        }

        public void ApplyInput()
        {
            Velocity.ApplyInput(_stats, _inputHandler.MovementVector);
        }
    }
}
