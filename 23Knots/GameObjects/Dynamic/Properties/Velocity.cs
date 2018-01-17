using System;
using Microsoft.Xna.Framework;

namespace _23Knots.GameObjects.Dynamic.Properties
{
    public class Velocity
    {
        public float Speed { get; set; }
        public float Direction { get; set; }

        public Vector2 AsVector
        {
            get => new Vector2((float)Math.Cos(Direction) * Speed, (float)Math.Sin(Direction) * Speed);
            set
            {
                Direction = (float)Math.Atan2(value.Y, value.X);
                Speed = (float)Math.Sqrt((Math.Pow(value.X, 2) + Math.Pow(value.Y, 2)));
            }
        }

        public Velocity(float speed = 0f, float direction = 0f)
        {
            Speed = speed;
            Direction = direction;
        }

        public void ApplyInput(Stats stats, Vector2 inputVector)
        {

            var desiredVelocity = inputVector * stats.MaxSpeed;
            AsVector = Vector2.LerpPrecise(AsVector, desiredVelocity, stats.Acceleration);
        }
    }
}
