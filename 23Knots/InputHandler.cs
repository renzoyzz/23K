using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Newtonsoft.Json;
using _23Knots.Input;

namespace _23Knots
{
    public class InputHandler
    {
        public float Direction { get; private set; }
        public float Magnitude { get; private set; }
        public KeyBindings KeyBindings { get; set; }
        public Movement Movement { get; set; }

        public Vector2 MovementVector => new Vector2((float)Math.Cos(Direction) * Magnitude, (float)Math.Sin(Direction) * Magnitude);

        public InputHandler()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Input/KeyBindings.json");
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                KeyBindings = JsonConvert.DeserializeObject<KeyBindings>(json);
            }
            Movement = KeyBindings.Movement;
        }



        public void EvaluateInput()
        {
            var keyboardState = Keyboard.GetState();
            var directionVector = new Vector2();
            var currentForce = 0f;
            if (keyboardState.IsKeyDown(Movement.Up))
            {
                currentForce = 1f;
                directionVector.Y--;
            }
            if (keyboardState.IsKeyDown(Movement.Down))
            {
                currentForce = 1f;
                directionVector.Y++;
            }
            if (keyboardState.IsKeyDown(Movement.Left))
            {
                currentForce = 1f;
                directionVector.X--;
            }
            if (keyboardState.IsKeyDown(Movement.Right))
            {
                currentForce = 1f;
                directionVector.X++;
            }
            Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            Magnitude = currentForce;
        }
    }
}
