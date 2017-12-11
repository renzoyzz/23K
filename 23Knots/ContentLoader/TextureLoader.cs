using _23Knots.GameObjects;

namespace _23Knots.ContentLoader
{
    public static class TextureLoader
    {

        public static void LoadContent()
        {
            Textures.GameObject = GameObject.LoadContent();
            Textures.Player = Player.LoadContent();
        }

    }
}
