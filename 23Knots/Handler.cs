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

        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        public Camera Camera { get; }
        public InputHandler InputHandler { get; }
        public float UpdateTimeCoefficient => (float)MainGame.Instance.UpdateStopwatch.Elapsed.TotalMilliseconds / (float)MainGame.Instance.TargetElapsedTime.TotalMilliseconds;

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
            InputHandler.EvaluateInput();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Tick();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera.Draw();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }
}