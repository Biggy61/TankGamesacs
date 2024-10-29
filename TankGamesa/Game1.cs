using System;
using System.Collections.Generic;
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
    Turret turret;
    Texture2D bulletTexture;
    Texture2D turretTexture;
    Texture2D backgroundTexture;
    public Vector2 Position;
    public float Timer;
    public Vector2 BulletDirection;
    KeyboardState state = Keyboard.GetState();
    public bool Shoot = true;
    private const float TTL = 3f;
    private List<Bullet> bullets;
    private const float BulletSpeed = 200f;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        bullets = new List<Bullet>();
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
        player = new Player(playerTexture, 100f);


        Texture2D turretTexture;
        turretTexture = Content.Load<Texture2D>(@"Turret");
        turret = new Turret(turretTexture, 100f);
        //bulletTexture = new Texture2D(GraphicsDevice, 1, 1);
        //bulletTexture.SetData<Color>(new Color[] { Color.White });
        bulletTexture = Content.Load<Texture2D>(@"Round");
        
        backgroundTexture = Content.Load<Texture2D>(@"background");
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))

            Exit();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var mouse = Mouse.GetState();
        // Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);
        // Vector2 Turretposition = new Vector2(Turret.TurretRect.X, Turret.TurretRect.Y);
        Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        //Vector2 direction = Vector2.Normalize(mousePosition - Turret.Rect);

        Vector2 direction = mousePosition - Player.TankPosition;
        direction.Normalize();
        Turret.TurretRotation = (float)Math.Atan2(direction.Y, direction.X);

        
        
        
        // if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        // {
        //     Vector2 BulletDirection = new Vector2((float)Math.Cos(Turret.TurretRotation), (float)Math.Sin(Turret.TurretRotation));
            
        //  
        // }
        // Bullet.Position += BulletDirection * (float)gameTime.ElapsedGameTime.TotalSeconds * player.Speed;
        //
        //
        //
        // if (Mouse.GetState().LeftButton == ButtonState.Pressed && !Shoot )
        // {
        //     Shoot = true;
        //     Position = Bullet.Position;
        //     BulletDirection = direction;
        //     bullet = new Bullet(bulletTexture, 100f, BulletDirection);
        // }
        //
        // if (Shoot)
        // {
        //     Position += BulletDirection * 3f;
        //     Timer += dt;
        //     if (Timer > 3)
        //     {
        //         Timer = 0;
        //         Shoot = false;
        //     }
        // }
        
        Console.WriteLine(mouse);

        float maxY = Window.ClientBounds.Height;
        float maxX = Window.ClientBounds.Width;
        player.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        turret.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        //bullet.BulletRect(Position);
        // player.Shoot(bulletTexture);
        
        var mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed && Shoot)
        {
            ShootProjectile();
            Shoot = false;
        }
        else if (mouseState.LeftButton == ButtonState.Released)
        {
            Shoot = true;
        }
        
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            bullets[i].Update(dt);
            
            if (bullets[i].LifeTime > TTL)
            {
                bullets.RemoveAt(i);
            }
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(backgroundTexture, new Vector2(0,0), Color.White);

        _spriteBatch.Draw(player.texture, player.PlayerRect, null, Color.White, Player.TankRotation,
            new Vector2(player.texture.Width / 2f, player.texture.Height / 1.7f), SpriteEffects.None, 0f);

        _spriteBatch.Draw(turret.texture, Turret.TurretRect, null, Color.White, Turret.TurretRotation,
            new Vector2(turret.texture.Width / 2f, turret.texture.Height / 1.5f), SpriteEffects.None, 0f);
        
        foreach (var shots in bullets)
        {
            shots.Draw(_spriteBatch);
        }
        _spriteBatch.End();
        // if (Shoot)
        // {
        //     _spriteBatch.Begin();
        //     _spriteBatch.Draw(bulletTexture, Position, bullet.BulletRect, Color.White);
        //     _spriteBatch.End();
        // }
       


        base.Draw(gameTime);
    }
    private void ShootProjectile()
    {
        Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        Vector2 projectileDirection = Vector2.Normalize(mousePosition - Player.TankPosition);

        Bullet newBullet = new Bullet(bulletTexture,  Player.TankPosition, projectileDirection, BulletSpeed, 0f);
        bullets.Add(newBullet);
    }
}