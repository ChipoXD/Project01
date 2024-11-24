using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Project01.Controllers;
using project01.Entities;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project01.Entities
{
        public class Player : BaseEntity
    {
        private readonly InputController _inputController;
        private float _deltaTime;
        public float Speed { get; set; }
        public override Vector2 Position { get; set; }
        public override Vector2 Direction {get; set;}
        private List<Bullet> _bullets = [];
        private Keys _upKey, _downKey, _leftKey, _rightKey;
        private static Texture2D _sprite;
        public Player() : this(new Vector2(100, 100), 1) { }

        public Player(Vector2 initialPosition, float initialSpeed)
        {
            _inputController = new InputController();
            ConfigureControls();
            SetInitialAtributes(initialPosition, initialSpeed);
        }

        public void ConfigureControls()
        {
            _upKey = Keys.W;
            _downKey = Keys.S;
            _leftKey = Keys.A;
            _rightKey = Keys.D;
        }
        
        public void SetInitialAtributes(Vector2 position, float speed)
        {
            Position = position;
            Speed = speed;
        }

        public static void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("Sprites/player");
        }

        public void Update(GameTime gameTime)
        {
            _deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            HandleInput();
            Move();
            _inputController.Update();
            _bullets.ForEach(bullet => bullet.Update(gameTime));
            _bullets.RemoveAll(bullet => bullet.IsExpired);
        }

        private void HandleInput()
        {
            var keyboardState = Keyboard.GetState();

            Direction = new Vector2(
                (_inputController.IsKeyHeld(_leftKey)  ? -1 : 0) +
                (_inputController.IsKeyHeld(_rightKey) ?  1 : 0), 
                (_inputController.IsKeyHeld(_upKey)    ? -1 : 0) +
                (_inputController.IsKeyHeld(_downKey)  ?  1 : 0)
            );
            
            if (_inputController.IsKeyPressed(Keys.Space) && Direction != Vector2.Zero)
            {
                SpawnBullet();
            }
        }
        private void Move()
        {
            Position = new Vector2(Position.X + Speed * _deltaTime * Direction.X, 
                                   Position.Y + Speed * _deltaTime * Direction.Y);
        }

        private void SpawnBullet()
        {
            _bullets.Add(new Bullet(this));
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
                scale:           new Vector2(3.0f, 3.0f),  // Scale 3x in both directions
                effects:         SpriteEffects.None,       // No special effects
                layerDepth:      0f                        // Draw at default depth
            );

            foreach (Bullet bullet in _bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
