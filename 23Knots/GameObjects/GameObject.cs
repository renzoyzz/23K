using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;
using _23Knots.GameObjects.Properties;

namespace _23Knots.GameObjects
{
    public class GameObject
    {
        protected Texture2D Texture;
        public Size Size = new Size(50, 50);
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
            var drawSize = new Rectangle(0, 0, Size.Width, Size.Height);
            spriteBatch.Draw(Texture, Position, drawSize, Color.White);
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
    }
}
