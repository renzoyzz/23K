using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23Knots.GameObjects.Properties
{
    public class Velocity
    {
        public float Speed { get; set; }
        public float Direction { get; set; }
      

        public Velocity(float speed = 0f, float direction = 0f)
        {
            Speed = speed;
            Direction = direction;
        }
    }
}
