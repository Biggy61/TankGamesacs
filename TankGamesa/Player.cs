using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class 
    Player : Sprite
{
    public static Vector2 TankPosition = Vector2.Zero;
    readonly float Speed;
    public static float TankRotation;

    public Rectangle PlayerRect => new((int)TankPosition.X, (int)TankPosition.Y + 10, 50, 100);
    
    public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
        Speed = speed;
    }


    
    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed)
    {
        KeyboardState state = Keyboard.GetState();
        float tankRotationSpeed = tankRotSpeed;


        if (state.IsKeyDown(Keys.D))
        {
            TankRotation += tankRotationSpeed * gametime;
            //TankPosition.X += 1;
        }

        if (state.IsKeyDown(Keys.A))
        {
            TankRotation -= tankRotationSpeed * gametime;
            //TankPosition.X -= 1;
        }
        
        if (state.IsKeyDown(Keys.W))
        {
             TankPosition.X += Speed * (float)Math.Sin(TankRotation) * gametime;
             TankPosition.Y -= Speed * (float)Math.Cos(TankRotation) * gametime;
             //TankPosition.Y -= 1;
        }
        
        if (state.IsKeyDown(Keys.S))
        {
            TankPosition.X -= Speed * (float)Math.Sin(TankRotation) * gametime;
            TankPosition.Y += Speed * (float)Math.Cos(TankRotation) * gametime;
            //TankPosition.Y += 1;
        }

        TankPosition.X = Single.Clamp(TankPosition.X, 0 + PlayerRect.Width, maxX - PlayerRect.Width);
        TankPosition.Y = Single.Clamp(TankPosition.Y, 0 + PlayerRect.Height / 2f, maxY - PlayerRect.Height / 2f);
    }
}