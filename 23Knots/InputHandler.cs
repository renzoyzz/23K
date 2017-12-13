using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23Knots
{
    public class InputHandler
    {
        public float Direction { get; private set; }
        public float Magnitude { get; private set; }

        public Vector2 MovementVector => new Vector2((float)Math.Cos(Direction) * Magnitude, (float)Math.Sin(Direction) * Magnitude);

        public void EvaluateInput()
        {
            var keyboardState = Keyboard.GetState();
            var directionVector = new Vector2();
            var currentForce = 0f;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                currentForce = 1f;
                directionVector.X++;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                currentForce = 1f;
                directionVector.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentForce = 1f;
                directionVector.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                currentForce = 1f;
                directionVector.Y--;
            }
            Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            Magnitude = currentForce;
        }
    }
}
