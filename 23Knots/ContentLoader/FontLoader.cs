using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _23Knots.ContentLoader
{
    public class FontLoader
    {
        public static void LoadContent(ContentManager content)
        {
            Fonts.Arial = content.Load<SpriteFont>("Arial");
        }
    }
}
