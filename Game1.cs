using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project01.Entities;
using project01.Ui;
using static System.Net.Mime.MediaTypeNames;

namespace Project01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private Label _label;
    private SpriteFont _font;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _player = new Player(new Vector2(100, 100), 100);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.LoadContent(Content);
        Bullet.LoadContent(Content);
        _font = Content.Load<SpriteFont>("Fonts/default");
        _label = new Label(_font, "Player: (100, 100)", new Vector2(10, 10));
    }

    protected override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        _label.Text = $"Player: {_player.Position}";
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _player.Draw(_spriteBatch);
        _label.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
