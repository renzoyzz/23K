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
        Viewport view;
        Vector2 center;
        Vector2 size;
        private GameObject _focusedGameObject;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public GameObject FocusedGameObject
        {
            set => _focusedGameObject = value;
        }

        public void Update(GameTime gameTime)
        {
            size = _focusedGameObject.getObjectSize();
            center = new Vector2(_focusedGameObject.Position.X + (size.X / 2) - (view.Width / 2), _focusedGameObject.Position.Y + (size.Y / 2) - (view.Height / 2));
            Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }

    }
}
