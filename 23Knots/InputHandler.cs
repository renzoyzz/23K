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
        public float direction;
        public float force;

        public float getDirection()
        {
            return direction;
        }

        public float getForce()
        {
            return force;
        }

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
            direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            force = currentForce;
        }
    }
}
