using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Project01.Controllers;
using System.Diagnostics;

namespace project01.Entities
{
    public class Bullet(BaseEntity entity) : BaseEntity
    {
        public sealed override Vector2 Position { get; set; } = entity.Position;
        public sealed override Vector2 Direction { get; set;} = entity.Direction;
        public float Speed { get; set; } = 200F;
        private const float Radius = 3f;
        private float _deltaTime;
        private static Texture2D _sprite;
        public bool IsExpired { get; private set; }
        private const float MaxLifeTime = 2f;
        private float _lifeTime = 0f;

        public override void Update(GameTime gameTime)
        {
            _deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position = new Vector2(Position.X + Direction.X * Speed * _deltaTime, Position.Y + Direction.Y * Speed * _deltaTime);

            _lifeTime += _deltaTime;
            IsExpired = _lifeTime >= MaxLifeTime;

        }
        public static void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("Sprites/bullet");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture:         _sprite,                  // Texture to draw
                position:        Position,                 // Position on screen
                sourceRectangle: null,                     // Draw the entire texture
                color:           Color.White,              // Color tint
                rotation:        0f,                       // No rotation
                origin:          Vector2.Zero,             // Origin point
                scale:           new Vector2(Radius),      // Scale Radius in both directions
                effects:         SpriteEffects.None,       // No special effects
                layerDepth:      0f                        // Draw at default depth
            );
        }
    }
}