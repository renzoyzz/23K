using _23Knots.GameObjects;
using _23Knots.GameObjects.Dynamic;
using _23Knots.GameObjects.DynamicGameObjects;

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
