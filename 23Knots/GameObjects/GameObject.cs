using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots;

namespace GameObjects
{
    public class GameObject
    {
        private Texture2D _texture;
        private Vector2 _position;
        public Vector2 Position { get; set; }

        public GameObject()
        {
            SetPosition(Vector2.Zero);
        }

        public GameObject(float xPos, float yPos)
        {
            SetPosition(xPos, yPos);
        }

        public GameObject(float pos)
        {
            SetPosition(pos);
        }

        public GameObject(Vector2 position)
        {
            SetPosition(position);
        }

        public void Initialize()
        {
        }

        public virtual void Tick()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, Color.AliceBlue);
        }

        public void SetPosition(float x, float y)
        {
            SetPosition(new Vector2(x, y));
        }

        public void SetPosition(float pos)
        {
            SetPosition(new Vector2(pos));
        }


        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}
