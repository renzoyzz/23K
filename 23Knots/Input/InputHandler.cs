using System;
using Microsoft.Xna.Framework;
using _23Knots.Input.Bindings;
using _23Knots.Input.Loader;

namespace _23Knots.Input
{
    public class InputHandler
    {
        public float Direction => (float) Math.Atan2(MovementVector.Y, MovementVector.X);
        public float Magnitude => (float) Math.Sqrt(Math.Pow(MovementVector.X, 2) + Math.Pow(MovementVector.Y, 2));

        public Vector2 MovementVector
        {
            get => _movementVector;
            private set
            {
                if (value != Vector2.Zero) value.Normalize();
                _movementVector = value;
            }
        }
        private Vector2 _movementVector = Vector2.Zero;

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
            MovementVector = new Vector2(_binding.HoriozontalValue, _binding.VerticalValue);
        }
    }
}
