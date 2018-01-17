using System;
using Microsoft.Xna.Framework;
using _23Knots.Input.Bindings;
using _23Knots.Input.Loader;

namespace _23Knots.Input
{
    public class InputHandler
    {
        public float Direction { get; private set; }
        public float Magnitude { get; private set; }
        public Vector2 MovementVector => new Vector2((float)Math.Cos(Direction) * Magnitude, (float)Math.Sin(Direction) * Magnitude);
        private readonly Binding _binding;

        public InputHandler()
        {
            var keyBindingsLoader = new KeyBindingsLoader();
            _binding = new Binding(keyBindingsLoader.KeyBindingsJson);
        }

        public void EvaluateInput()
        {
            _binding.EvaluateKeys();
            EvaluateMovement();
        }

        private void EvaluateMovement()
        {
            var directionVector = new Vector2(_binding.HoriozontalValue, _binding.VerticalValue);
            if (directionVector != Vector2.Zero)
                directionVector.Normalize();
            Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            Magnitude = (float)Math.Sqrt(Math.Pow(directionVector.X, 2) + Math.Pow(directionVector.Y, 2));
        }
    }
}
