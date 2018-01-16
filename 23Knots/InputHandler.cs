﻿using Microsoft.Xna.Framework;
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
        public Vector2 MovementVector => new Vector2((float)Math.Cos(Direction) * Magnitude, (float)Math.Sin(Direction) * Magnitude);
        private KeyboardState _keyboardState = Keyboard.GetState();

        public InputHandler()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Input/KeyBindings.json");
            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                KeyBindings = JsonConvert.DeserializeObject<KeyBindings>(json);
            }
        }

        public void EvaluateInput()
        {
            _keyboardState = Keyboard.GetState();
            EvaluateMovement();  
        }

        private void EvaluateMovement()
        {
            var move = KeyBindings.Move;
            var directionVector = new Vector2();
            var currentForce = 0f;
            if (IsKeyDown(move.Up))
            {
                currentForce = 1f;
                directionVector.Y--;
            }
            if (IsKeyDown(move.Down))
            {
                currentForce = 1f;
                directionVector.Y++;
            }
            if (IsKeyDown(move.Left))
            {
                currentForce = 1f;
                directionVector.X--;
            }
            if (IsKeyDown(move.Right))
            {
                currentForce = 1f;
                directionVector.X++;
            }
            Direction = (float)Math.Atan2(directionVector.Y, directionVector.X);
            Magnitude = currentForce;
        }


        public bool IsKeyDown(Keys key)
        {
            return _keyboardState.IsKeyDown(key);
        }
    }
}
