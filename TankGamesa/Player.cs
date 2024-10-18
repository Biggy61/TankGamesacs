using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class Player
{
    public static Vector2 _spritePosition = Vector2.Zero;
    public void Move()
    {
           KeyboardState state = Keyboard.GetState();
        
                    if (state.IsKeyDown(Keys.D))
                    {
                        _spritePosition.X += 1;
                    }
        
                    if (state.IsKeyDown(Keys.A))
                    {
                        _spritePosition.X -= 1;
                    }
        
                    if (state.IsKeyDown(Keys.W))
                    {
                        _spritePosition.Y -= 1;
                    }
        
                    if (state.IsKeyDown(Keys.S))
                    {
                        _spritePosition.Y += 1;
                    }
    }
         
       
    
     
    
}

