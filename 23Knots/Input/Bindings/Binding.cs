using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using _23Knots.Input.Loader;

namespace _23Knots.Input.Bindings
{
    public class Binding
    {
        public Key UpKey { get; set; }
        public Key DownKey { get; set; }
        public Key LeftKey { get; set; }
        public Key RightKey { get; set; }
        public float HoriozontalValue { get; set; } = (float)Value.Center;
        public float VerticalValue { get; set; } = (float)Value.Center;
        public List<Key> Keys { get; set; } = new List<Key>();

        public Binding(KeyBindingsJson keyBindings)
        {
            UpKey = new Key(keyBindings.Up);
            DownKey = new Key(keyBindings.Down);
            LeftKey = new Key(keyBindings.Left);
            RightKey = new Key(keyBindings.Right);
            InitalizeKeys(UpKey, DownKey, LeftKey, RightKey);
        }

        public void InitalizeKeys(params Key[] keys)
        {
            Keys.AddRange(keys);
        }

        public void EvaluateKeys()
        {
            var keyboardState = Keyboard.GetState();
            foreach (var key in Keys)
            {
                key.Evaluate(keyboardState);
            }
            EvaluateHorizontalValue();
            EvaluateVerticalValue();
        }

        public void EvaluateHorizontalValue()
        {
            if (RightKey.IsPressed && LeftKey.IsPressed)
            {
                if (RightKey.WasPressed && LeftKey.WasPressed)
                    HoriozontalValue = (float)Value.Max;
                else if (RightKey.WasPressed)
                    HoriozontalValue = (float)Value.Max;
                else if (LeftKey.WasPressed)
                    HoriozontalValue = (float)Value.Min;
            }
            else if (RightKey.IsPressed)
                HoriozontalValue = (float)Value.Max;
            else if (LeftKey.IsPressed)
                HoriozontalValue = (float)Value.Min;
            else if (!RightKey.IsPressed && !LeftKey.IsPressed)
                HoriozontalValue = (float)Value.Center;
        }

        public void EvaluateVerticalValue()
        {
            if (UpKey.IsPressed && DownKey.IsPressed)
            {
                if (UpKey.WasPressed && DownKey.WasPressed)
                    VerticalValue = (float)Value.Min;
                else if (UpKey.WasPressed)
                    VerticalValue = (float)Value.Min;
                else if (DownKey.WasPressed)
                    VerticalValue = (float)Value.Max;
            }
            else if (UpKey.IsPressed)
                VerticalValue = (float)Value.Min;
            else if (DownKey.IsPressed)
                VerticalValue = (float)Value.Max;
            else if (!UpKey.IsPressed && !DownKey.IsPressed)
                VerticalValue = (float)Value.Center;
        }
    }
}
