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
        private Vector2 _center;
        private GameObject _focusedGameObject;

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
            var focusedObjectSize = _focusedGameObject.Size;
            var centerX = _focusedGameObject.Position.X + (focusedObjectSize.Width / 2f) - (_view.Width / 2f);
            var centerY = _focusedGameObject.Position.Y + (focusedObjectSize.Height / 2f) - (_view.Height / 2f);
            _center = new Vector2(centerX, centerY);
            Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-_center.X, -_center.Y, 0));
        }

    }
}
