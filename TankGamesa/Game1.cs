using System.Media;
using System.Windows.Forms.VisualStyles;
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
        Window.Title = "almost War Thunder";
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
        player = new Player(playerTexture, Vector2.Zero, 100f);

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
        float maxY = Window.ClientBounds.Height;
        float maxX = Window.ClientBounds.Width;
        player.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.Draw(player.texture, player.Rect, null, Color.White, Player.TankRotation, new Vector2(player.texture.Width / 2f, player.texture.Height / 2f), SpriteEffects.None, 0f);
        //_spriteBatch.Draw(bullet.texture, bullet.Rect, null, Color.White, bullet.speed, new Vector2(player.texture.Width /2f, player.texture.Height), SpriteEffects.None, 0f);   
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}