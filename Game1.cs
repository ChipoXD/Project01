using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project01.Entities;
using Project01.Ui;
using Project01.Controllers;
using static System.Net.Mime.MediaTypeNames;

namespace Project01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private Label _label;
    private SpriteFont _font;
    private Button _toggleHideButton;
    private UiManager _uiManager = new UiManager();

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
        _label = new Label(_font, $"Player: {_player.Position}", new Vector2(10, 10));
        _toggleHideButton = new Button(new Rectangle(5, 35, 150, 30), "Turn Off Coordinates", _font);

        _toggleHideButton.OnClick += () => _label.ToggleVisibility();

        _uiManager.AddComponent(_label);
        _uiManager.AddComponent(_toggleHideButton);
    }

    protected override void Update(GameTime gameTime)
    {
        _label.Text = $"Player: {_player.Position}";
        _player.Update(gameTime);
        InputController.Update(gameTime);
        _uiManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _uiManager.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
