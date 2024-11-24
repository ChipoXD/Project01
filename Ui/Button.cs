using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project01.Ui;

namespace Project01.Ui
{
    internal class Button( Texture2D texture, Vector2 position ) : BaseUi
    {
        private Texture2D _texture = texture;
        private Vector2 _position = position;
        private Rectangle _rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        public bool IsHovered { get; private set; }
        public bool IsClicked { get; private set; }
        public Action OnClick { get; set; }
        public Action OnHovered { get; set; }


        public override Vector2 Position { get; set; }
        public override void Update(GameTime gameTime)
        {
            var currentMouseState = Mouse.GetState();
            var mousePosition = currentMouseState.Position;

            // Check if mouse is over the button
            IsHovered = _rectangle.Contains(mousePosition);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
