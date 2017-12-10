using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameObjects
{
    public class GameObject
    {
        private Vector2 _position = new Vector2();
        public Vector2 Position { get; set; }

        public GameObject(float xPos, float yPos)
        {
            SetPosition(xPos, yPos);
        }

        public GameObject(Vector2 position)
        {
            SetPosition(position);
        }

        public void SetPosition(float x, float y)
        {
            SetPosition(new Vector2(x, y));
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }



    }
}
