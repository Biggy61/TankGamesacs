using System;
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
    Turret turret;
    Texture2D bulletTexture;
    public Vector2 Position = Vector2.Zero;
    KeyboardState state = Keyboard.GetState();
    static MouseState mouse = Mouse.GetState();
    public static Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);
    public static Vector2 direction = mousePosition - Player.TankPosition;
    public Rectangle BulletRect
    {
      get {return new Rectangle((int)Position.X,(int) Position.Y, 2, 2); }
    }

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
        playerTexture = Content.Load<Texture2D>(@"Body");
        player = new Player(playerTexture, Vector2.Zero, 100f);


        Texture2D turretTexture;
        turretTexture = Content.Load<Texture2D>(@"Turret");
        turret = new Turret(turretTexture, Vector2.Zero, 100f);
        
        //bulletTexture = new Texture2D(GraphicsDevice, 1, 1);
        //bulletTexture.SetData<Color>(new Color[] { Color.White });
        bulletTexture = Content.Load<Texture2D>(@"Round");
        bullet = new Bullet(bulletTexture, Position,  100f, direction);
        
    }

    protected override void Update(GameTime gameTime)
    {        
        direction.Normalize();
        Position += direction * bullet.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


   
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        float maxY = Window.ClientBounds.Height;
        float maxX = Window.ClientBounds.Width;
        player.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        turret.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        bullet.ShootBullet(Position);
        // player.Shoot(bulletTexture);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // if (mouse.LeftButton == ButtonState.Pressed )
        // { 
        //     _spriteBatch.Begin();
        //     _spriteBatch.Draw(bullet.texture, bullet.BulletRect, Color.White);  
        //     _spriteBatch.End();
        // }

      

        _spriteBatch.Begin();
        //bullet.Draw(_spriteBatch, bulletTexture, direction);
        _spriteBatch.Draw(bulletTexture, BulletRect, Color.White);
        _spriteBatch.Draw(player.texture, player.PlayerRect, null, Color.White, Player.TankRotation, new Vector2(player.texture.Width / 2f, player.texture.Height / 1.7f), SpriteEffects.None, 0f);
        _spriteBatch.Draw(turret.texture, Turret.TurretRect, null, Color.White, Turret.TurretRotation, new Vector2(turret.texture.Width /2f, turret.texture.Height /1.5f), SpriteEffects.None, 0f);
        _spriteBatch.End();
    
       
        
          
            
        base.Draw(gameTime);
    }
    

}