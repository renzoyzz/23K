using Microsoft.Xna.Framework.Input;

namespace _23Knots.Input.Bindings
{
    public class Key
    {
        public Keys Code { get; set; }
        public bool IsPressed { get; set; }
        public bool WasPressed { get; set; }
        public bool WasReleased { get; set; }

        public Key(Keys key)
        {
            Code = key;
        }

        public void Evaluate(KeyboardState keyboardState)
        {
            ResetWasPressedAndWasReleased();
            var isPressedTemp = keyboardState.IsKeyDown(Code);
            if (isPressedTemp && !IsPressed)
                WasPressed = true;
            else if (!isPressedTemp && IsPressed)
                WasReleased = true;
            IsPressed = isPressedTemp;
        }

        private void ResetWasPressedAndWasReleased()
        {
            WasPressed = false;
            WasReleased = false;
        }
    }
}
