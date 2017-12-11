using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.GameObjects;

namespace _23Knots
{
    public class Handler
    {
        private static Handler _instance;
        public static Handler Instance => _instance ?? (_instance = new Handler());

        private readonly List<GameObject> _gameObjects = new List<GameObject>();

        public Handler()
        {
            _gameObjects.Add(new GameObject());
            _gameObjects.Add(new Player());
        }

        public void Tick()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Tick();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();
        }


    }
}
