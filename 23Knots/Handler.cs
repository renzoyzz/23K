using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using _23Knots.GameObjects;
using Microsoft.Xna.Framework;
using _23Knots.GameObjects.Dynamic;

namespace _23Knots
{
    public class Handler
    {
        private static Handler _instance;

        public static Handler Instance => _instance ?? (_instance = new Handler());

        public Camera Camera { get; }
        public InputHandler InputHandler { get; }
        private readonly List<GameObject> _gameObjects = new List<GameObject>();

        private Handler()
        {
            _instance = this;
            Camera = new Camera(MainGame.Instance.GraphicsDevice.Viewport);
            InputHandler = new InputHandler();
            _gameObjects.Add(new GameObject());
            var player = new Player();
            _gameObjects.Add(player);
            Camera.FocusedGameObject = player;
        }

        public void Tick(GameTime gameTime)
        {
            Camera.Update(gameTime);
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Tick();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }


    }
}