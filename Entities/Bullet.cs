using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Project01.Controllers;
using System.Diagnostics;

namespace project01.Entities
{
    public class Bullet : BaseEntity
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Direction { get; set;}
        public float Speed { get; set; } = 2F;
        private const float _radius = 3f;
        private float _deltaTime;
        private static Texture2D _sprite;
        public bool IsExpired { get; private set; }
        private const float MaxLifeTime = 2f;
        private float _lifeTime = 0f;

        public Bullet(BaseEntity Entity)
        {
            Position = Entity.Position;
            Direction = Entity.Direction;
        }

        public void Update(GameTime gameTime)
        {
            _deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position = new Vector2(Position.X + Direction.X * Speed , Position.Y + Direction.Y * Speed);

            _lifeTime += _deltaTime;
            IsExpired = _lifeTime >= MaxLifeTime;

            Debug.WriteLine($"Bullet lifetime: {_lifeTime} seconds and expired = {IsExpired}");
        }
        public static void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("Sprites/bullet");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture:         _sprite,                  // Texture to draw
                position:        Position,                 // Position on screen
                sourceRectangle: null,                     // Draw the entire texture
                color:           Color.White,              // Color tint
                rotation:        0f,                       // No rotation
                origin:          Vector2.Zero,             // Origin point
                scale:           new Vector2(_radius),      // Scale Radius in both directions
                effects:         SpriteEffects.None,       // No special effects
                layerDepth:      0f                        // Draw at default depth
            );
        }
    }
}