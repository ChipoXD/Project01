using Microsoft.Xna.Framework;

namespace project01.Entities
{
    public abstract class BaseEntity
    {
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Direction { get; set; }
        
    }
}