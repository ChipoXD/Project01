using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project01.Ui
{
    public abstract class BaseUi
    {
        public abstract Vector2 Position { get; set; }
        public bool IsVisible { get; set; } = true;
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }
    }
}