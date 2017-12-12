using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23Knots.GameObjects.Properties
{
    public class Stats
    {
        public float Acceleration { get; set; }
        public float MaxSpeed { get; set; }

        public Stats(float acceleration = 0f, float maxSpeed = 0f)
        {
            Acceleration = acceleration;
            MaxSpeed = maxSpeed;
        }

    }
}
