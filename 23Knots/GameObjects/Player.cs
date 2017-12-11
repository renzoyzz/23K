using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.ContentLoader;

namespace _23Knots.GameObjects
{
    public class Player : GameObject
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
            Position.X++;
            base.Tick();
        }
    }
}
