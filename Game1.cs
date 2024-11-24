using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project01.Entities;
using project01.Entities;

namespace Project01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player player;  
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new Player(new Vector2(100, 100), 100);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.LoadContent(Content);
        Bullet.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        player.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            player.Draw(_spriteBatch);

            _spriteBatch.End();

        base.Draw(gameTime);
    }
}
