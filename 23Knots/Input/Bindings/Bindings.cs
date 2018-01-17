using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using _23Knots.Input.Loader;

namespace _23Knots.Input.Bindings
{
    public class Bindings
    {
        public Key UpKey { get; set; }
        public Key DownKey { get; set; }
        public Key LeftKey { get; set; }
        public Key RightKey { get; set; }
        public List<Key> Keys { get; set; } = new List<Key>();

        public Bindings(KeyBindingsJson keyBindings)
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
        }


    }
}
