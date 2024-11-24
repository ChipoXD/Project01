using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project01.Controllers
{
        public class InputController
    {
        private static KeyboardState _keyState;
        private static KeyboardState _prevKeyState;
        private static MouseState _mouseState;
        private static MouseState _prevMouseState;

        public static void Update(GameTime gameTime)
        {
            _prevKeyState = _keyState;
            _keyState = Keyboard.GetState();
            _prevMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            return _keyState.IsKeyDown(key) && !_prevKeyState.IsKeyDown(key);
        }

        public static bool IsKeyHeld(Keys key)
        {
            return _keyState.IsKeyDown(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            return !_keyState.IsKeyDown(key) && _prevKeyState.IsKeyDown(key);
        }

        public static bool IsLeftClick()
        {
            return _mouseState.LeftButton == ButtonState.Pressed && _prevMouseState.LeftButton == ButtonState.Released;
        }

        public static bool IsRightClick()
        {
            return _mouseState.RightButton == ButtonState.Pressed && _prevMouseState.RightButton == ButtonState.Released;
        }

        public static bool IsMiddleClick()
        {
            return _mouseState.LeftButton == ButtonState.Pressed && _prevMouseState.LeftButton == ButtonState.Released;
        }
    }
}
