using Microsoft.Xna.Framework.Input;

namespace Project01.Controllers
{
        public class InputController
    {
        private KeyboardState _keyState;
        private KeyboardState _prevKeyState;

        public void Update()
        {
            _prevKeyState = _keyState;
            _keyState = Keyboard.GetState();
        }

        public bool IsKeyPressed(Keys key)
        {
            return _keyState.IsKeyDown(key) && !_prevKeyState.IsKeyDown(key);
        }

        public bool IsKeyHeld(Keys key)
        {
            return _keyState.IsKeyDown(key);
        }

        public bool IsKeyReleased(Keys key)
        {
            return !_keyState.IsKeyDown(key) && _prevKeyState.IsKeyDown(key);
        }
    }
}
