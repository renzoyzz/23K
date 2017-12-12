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
        public float Acceleration { get; set; }
        public float Direction { get; set; }
        public float MaxSpeed { get; set; }

        public Velocity(float maxSpeed = 0f, float acceleration = 0f, float speed = 0f, float direction = 0f)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            Speed = speed;
            Direction = direction;
        }



    }
}
