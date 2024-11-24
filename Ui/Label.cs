using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace project01.Ui
{
    public class Label(SpriteFont font, string text, Vector2 position) : BaseUi
    {
        public override Vector2 Position { get; set; } = position;

        private readonly SpriteFont _font = font;
        public string Text = text;

        public Color TextColor { get; set; } = Color.Black;
        public override void Update(GameTime gameTime) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                _font,
                Text,
                position,
                TextColor
            );
        }
    }
}
