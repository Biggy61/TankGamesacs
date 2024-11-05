using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
    Enemy enemy;
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
    private const float BulletSpeed = 600f;
    public float timer;
    public float enemyTimer;
    Song song;

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
        song = Content.Load<Song>("Song");
        MediaPlayer.Play(song);
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D playerTexture;

        playerTexture = Content.Load<Texture2D>(@"Body");
        player = new Player(playerTexture, 100f);


        Texture2D turretTexture;
        turretTexture = Content.Load<Texture2D>(@"Turret");
        turret = new Turret(turretTexture, 100f);

        bulletTexture = Content.Load<Texture2D>(@"Round");

        Texture2D enemyTexture;
        enemyTexture = Content.Load<Texture2D>(@"JpzE100");
        enemy = new Enemy(enemyTexture, 100f, 100);
        backgroundTexture = Content.Load<Texture2D>(@"background");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))

            Exit();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var mouse = Mouse.GetState();
        Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

        Vector2 direction = mousePosition - Player.TankPosition;
        direction.Normalize();
        turret.TurretRotation = (float)Math.Atan2(direction.Y, direction.X) + Single.Pi / 2;


        // Console.WriteLine(mouse);

        float maxY = Window.ClientBounds.Height;
        float maxX = Window.ClientBounds.Width;
        player.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f, enemy.EnemyRect);
        turret.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 5f);
        enemyTimer += dt;
        if (enemyTimer > 0.5)
        {
            enemy.Move(maxX, maxY, (float)gameTime.ElapsedGameTime.TotalSeconds, 1f);
         
            enemyTimer = 0;
        } 

        var mouseState = Mouse.GetState();
        timer += dt;
        if (mouseState.LeftButton == ButtonState.Pressed && Shoot && timer > 2)
        {
            ShootProjectile();
            Shoot = false;
            timer = 0;
        }
        else if (mouseState.LeftButton == ButtonState.Released)
        {
            Shoot = true;
        }

        for (int i = bullets.Count - 1; i >= 0; i--)
        {

            bullets[i].Update(dt, enemy.EnemyRect);
            if (bullets[i].BulletRect.Intersects(enemy.EnemyRect))
            {
                Console.WriteLine("xdddd");
                bullets.RemoveAt(i);
            }

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

        _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);

        _spriteBatch.Draw(enemy.texture, enemy.EnemyRect, null, Color.White, enemy.TankRotation,
            new Vector2(enemy.texture.Width / 2f, enemy.texture.Height / 1.7f), SpriteEffects.None, 0f);


        _spriteBatch.Draw(player.texture, player.PlayerRect, null, Color.White, player.TankRotation,
            new Vector2(player.texture.Width / 2f, player.texture.Height / 1.7f), SpriteEffects.None, 0f);

        _spriteBatch.Draw(turret.texture, Turret.TurretRect, null, Color.White, turret.TurretRotation,
            new Vector2(turret.texture.Width / 2f, turret.texture.Height / 1.5f), SpriteEffects.None, 0f);

        foreach (var shots in bullets)
        {
            shots.Draw(_spriteBatch);
        }

        _spriteBatch.End();


        base.Draw(gameTime);
    }

    private void ShootProjectile()
    {
        Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        Vector2 position = new Vector2(Turret.TurretRect.X, Turret.TurretRect.Y);
        Vector2 projectileDirection = Vector2.Normalize(mousePosition - position);

        Bullet newBullet = new Bullet(bulletTexture, Player.TankPosition, projectileDirection, BulletSpeed, 0f);

        bullets.Add(newBullet);
    }
}