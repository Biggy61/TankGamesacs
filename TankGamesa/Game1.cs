using System.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Player player;
    Bullet bullet;
    KeyboardState state = Keyboard.GetState();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Window.AllowUserResizing = true;
        Window.AllowAltF4 = true;
        
        // TODO: Add your initialization logic here
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D playerTexture;
        //playerTexture = new Texture2D(GraphicsDevice, 1, 1);
        //playerTexture.SetData<Color>(new Color[] { Color.White });
        playerTexture = Content.Load<Texture2D>(@"JpzE100");
        player = new Player(playerTexture, Vector2.Zero, 2f);
        
        Texture2D bulletTexture;
        bulletTexture = new Texture2D(GraphicsDevice, 1, 1);
        bulletTexture.SetData<Color>(new Color[] { Color.White });
        bulletTexture = Content.Load<Texture2D>(@"Round");
        bullet = new Bullet(bulletTexture, Vector2.Zero, 2f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        player.Move();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.Draw(player.texture, Player.spritePosition, Color.White);
        _spriteBatch.Draw(bullet.texture, bullet.position, Color.White);   
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}