﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = SharpDX.Vector2;

namespace TankGamesa;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    private Vector2 _spritePosition = Vector2.Zero;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { Color.White });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState state = Keyboard.GetState();



        if (state.IsKeyDown(Keys.Right))
        {
            _spritePosition.X += 1;
        }
        if (state.IsKeyDown(Keys.Left))
        {
            _spritePosition.X -= 1;
        }
        if (state.IsKeyDown(Keys.Up))
        {
            _spritePosition.Y -= 1;
        }
        if (state.IsKeyDown(Keys.Down))
        {
            _spritePosition.Y += 1;
        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }



    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        Rectangle rectangle = new Rectangle(0,0, 50, 50);
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_texture, _spritePosition, rectangle, Color.White);
        _spriteBatch.End();
        
        
        base.Draw(gameTime);
    }
}
