using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class Player : Sprite
{
    public static Vector2 spritePosition = Vector2.Zero;
    public float speed;
    float DT = (float)GameTime.ElapsedGameTime.TotalSeconds;
    public float rotation = DT; 
    public static Rectangle rect
    {
        get
        {
            return new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)rect.Width, (int)rect.Height);
        }
    }

    public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position)
    {
        this.speed = speed;
    }

    public void Move()
    {
           KeyboardState state = Keyboard.GetState();
        
                    if (state.IsKeyDown(Keys.D))
                    {
                        spritePosition.X += speed;
                    }
        
                    if (state.IsKeyDown(Keys.A))
                    {
                        spritePosition.X -= speed;
                    }
        
                    if (state.IsKeyDown(Keys.W))
                    {
                        spritePosition.Y -= speed;
                    }
        
                    if (state.IsKeyDown(Keys.S))
                    {
                        spritePosition.Y += speed;
                    }
                    // spritePosition.X = Single.Clamp(spritePosition.X, 0, Window.ClientBounds.Width);
                    spritePosition.Y = Single.Clamp(spritePosition.Y, 0, GraphicsDevice.Viewport.Height);     
    }
         
       
    
     
    
}

