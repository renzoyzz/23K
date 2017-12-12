using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _23Knots.GameObjects.Properties
{
    public class Size
    {
        private Point _size;


        public Size(int width, int height)
        {
            SetDimensions(width, height);
        }

        public Size(Point size)
        {
            SetDimensions(size);
        }

        public int Width
        {
            get => _size.X;
            set => _size.X = value;
        }

        public int Height
        {
            get => _size.Y;
            set => _size.Y = value;
        }

        public Size SetDimensions(int width, int height)
        {
            _size = new Point(width, height);
            return this;
        }

        public Size SetDimensions(Point size)
        {
            return SetDimensions(size.X, size.Y);
        }
    }
}
