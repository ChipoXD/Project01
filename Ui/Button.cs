using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using Project01.Controllers;
using Project01.Ui;
using static System.Net.Mime.MediaTypeNames;

namespace Project01.Ui
{
    internal class Button( Rectangle bounds, string text, SpriteFont font) : BaseUi
    {
        private readonly string _text = text;
        private readonly SpriteFont _font = font;
        private Rectangle _bounds = bounds;
        public bool IsHovered { get; private set; }
        public bool IsClicked { get; private set; }
        public Action OnClick { get; set; }
        public Action OnHovered { get; set; }


        public override Vector2 Position { get; set; }
        public override void Update(GameTime gameTime)
        {
            IsHovered = _bounds.Contains(InputController.MousePosition());
            IsClicked = IsHovered && InputController.IsLeftClick();

            if (IsHovered) OnHovered?.Invoke();
            if (IsClicked) OnClick?.Invoke();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(_bounds,Color.Gray);

            if (string.IsNullOrEmpty(_text)) return;

            var textSize = _font.MeasureString(_text);
            var textPosition = new Vector2(
                _bounds.X + (_bounds.Width - textSize.X) / 2,
                _bounds.Y + (_bounds.Height - textSize.Y) / 2
            );

            spriteBatch.DrawString(
                spriteFont: _font, // The SpriteFont used for the text
                text: _text,
                position: textPosition,
                color: IsHovered ? Color.White : Color.Black
            );
        }
    }
}
