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
    public float TankRotation;
    public Rectangle PlayerRect => new((int)TankPosition.X, (int)TankPosition.Y + 10, 50, 100);

    public Player(Texture2D texture, float speed) : base(texture, speed)
    {
        Speed = speed;
    }


    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed, Rectangle Rect)
    {
        KeyboardState state = Keyboard.GetState();
        float tankRotationSpeed = tankRotSpeed;


        if (state.IsKeyDown(Keys.D))
        {
            TankRotation += tankRotationSpeed * gametime;
        }

        if (state.IsKeyDown(Keys.A))
        {
            TankRotation -= tankRotationSpeed * gametime;
        }

        if (state.IsKeyDown(Keys.W))
        {
            TankPosition.X += Speed * (float)Math.Sin(TankRotation) * gametime;
            TankPosition.Y -= Speed * (float)Math.Cos(TankRotation) * gametime;
        }
        
        if (state.IsKeyDown(Keys.S))
        {
            TankPosition.X -= Speed * (float)Math.Sin(TankRotation) * gametime;
            TankPosition.Y += Speed * (float)Math.Cos(TankRotation) * gametime;
        }

        TankPosition.X = Single.Clamp(TankPosition.X, 0 + PlayerRect.Height / 2.3f, maxX - PlayerRect.Height / 2.3f);
        TankPosition.Y = Single.Clamp(TankPosition.Y, 0 + PlayerRect.Height / 3f, maxY - PlayerRect.Height / 2f);
    }
}