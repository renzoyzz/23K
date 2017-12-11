﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.GameObjects
{
    public class GameObject
    {
        protected Texture2D Texture;
        public Vector2 Position;

        public GameObject()
        {
            Initialize();
            SetPosition(Vector2.Zero);
        }

        public GameObject(Vector2 position)
        {
            Initialize();
            SetPosition(position);
        }

        public static Texture2D LoadContent()
        {
            var texture = new Texture2D(MainGame.Instance.Graphics.GraphicsDevice, 1, 1);
            var dataColors = new[]
            {
                Color.Red
            };
            texture.SetData(dataColors);
            return texture;
        }

        private void Initialize()
        {
            Texture = Textures.GameObject;
        }

        public virtual void Tick()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, 50, 50), Color.White);
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
    }
}