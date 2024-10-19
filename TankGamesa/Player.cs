using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class Player : Sprite
{
    public static Vector2 spritePosition = Vector2.Zero;
    public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
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
    }
         
       
    
     
    
}

