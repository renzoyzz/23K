using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _23Knots.GameObjects
{
    public class GameObject
    {
        private static Texture2D _texture;
        private Vector2 _position;
        public Vector2 Position { get; set; }

        public GameObject()
        {
            SetPosition(Vector2.Zero);
        }

        public GameObject(Vector2 position)
        {
            SetPosition(position);
        }

        public static void LoadContent()
        {
            _texture = new Texture2D(MainGame.Instance.Graphics.GraphicsDevice, 1, 1);
            var dataColors = new[]
            {
                Color.Red
            };
            _texture.SetData(dataColors);
        }

        public virtual void Tick()
        {
            _position.X++;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 50, 50), Color.White);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}
