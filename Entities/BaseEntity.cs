using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project01.Entities
{
    public abstract class BaseEntity
    {
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Direction { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}