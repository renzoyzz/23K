using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.GameObjects;
using Microsoft.Xna.Framework;

namespace _23Knots
{
    public class Handler
    {
        private static Handler _instance;
        public static Handler Instance => _instance ?? (_instance = new Handler());
        public GameObject FocustedGameObject { private get; set; }

        private readonly List<GameObject> _gameObjects = new List<GameObject>();

        private Player player;

        public Handler()
        {
            _gameObjects.Add(new GameObject());
            _gameObjects.Add(player = new Player());
        }

        public void Tick(GameTime gameTime, Camera camera)
        {
            camera.FocusedGameObject = player;
            camera.Update(gameTime);
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Tick();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }


    }
}