using _23Knots.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23Knots
{
    public class Camera
    {
        public Matrix Transform;
        private Viewport _view;
        private GameObject _focusedGameObject;
        private Vector2 _previousPosition;
        public Vector2 Position { get; private set; }
        public Vector2 DrawPosition { get; private set; }

        public Camera(Viewport newView)
        {
            _view = newView;
        }

        public GameObject FocusedGameObject
        {
            set => _focusedGameObject = value;
        }

        public void Update(GameTime gameTime)
        {
            _previousPosition = Position;
            var focusedObjectSize = _focusedGameObject.Size;
            var posX = _focusedGameObject.Position.X + (focusedObjectSize.Width / 2f) - (_view.Width / 2f);
            var posY = _focusedGameObject.Position.Y + (focusedObjectSize.Height / 2f) - (_view.Height / 2f);
            Position = Vector2.Lerp(_previousPosition, new Vector2(posX, posY), 0.5f);
        }

        public void Draw()
        {
            DrawPosition = Vector2.Lerp(_previousPosition, Position, Handler.Instance.UpdateTimeCoefficient);
            Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-DrawPosition.X, -DrawPosition.Y, 0));
        }
    }
}
