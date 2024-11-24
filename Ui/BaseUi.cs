using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project01.Ui
{
    public abstract class BaseUi
    {
        public abstract Vector2 Position { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}