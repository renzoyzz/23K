using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right))
                Position.X++;
            else if (keyboardState.IsKeyDown(Keys.Down))
                Position.Y++;
            else if (keyboardState.IsKeyDown(Keys.Left))
                Position.X--;
            else if (keyboardState.IsKeyDown(Keys.Up))
                Position.Y--;
            base.Tick();
        }
    }
}
