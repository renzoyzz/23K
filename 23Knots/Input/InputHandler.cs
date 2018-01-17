using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using _23Knots.Input.Loader;

namespace _23Knots.Input
{
    public class InputHandler
    {
        public float Direction { get; private set; }
        public float Magnitude { get; private set; }
        public Vector2 MovementVector => new Vector2((float)Math.Cos(Direction) * Magnitude, (float)Math.Sin(Direction) * Magnitude);
        private Bindings.Bindings _bindings;

        public InputHandler()
        {
           var keyBindingsLoader = new KeyBindingsLoader();
            _bindings = new Bindings.Bindings(keyBindingsLoader.KeyBindingsJson);
        }

        public void EvaluateInput()
        {
            _bindings.EvaluateKeys();
            EvaluateMovement();  
        }

        private void EvaluateMovement()
        {
            //Evaluate last key pressed.
            var directionVector = new Vector2();
            var currentForce = 0f;
            if (_bindings.UpKey.IsPressed)
            {
                currentForce = 1f;
                directionVector.Y--;
            }
            if (_bindings.DownKey.IsPressed)
            {
                currentForce = 1f;
                directionVector.Y++;
            }
            if (_bindings.LeftKey.IsPressed)
            {
                currentForce = 1f;
                directionVector.X--;
            }
            if (_bindings.RightKey.IsPressed)
            {
                currentForce = 1f;
                directionVector.X++;
            }
            Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            Magnitude = currentForce;
        }
    }
}
