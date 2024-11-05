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
    float Rotchange;
    float changeX;
    float changeY;
   float changeXX;
    float changeYY;
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
            Rotchange += tankRotationSpeed * gametime;
        }

        if (state.IsKeyDown(Keys.A))
        {
            Rotchange -= tankRotationSpeed * gametime;
        }

        TankRotation = Rotchange;
         if (PlayerRect.Intersects(Rect))
         {
             TankRotation -= Rotchange;
         }

        if (state.IsKeyDown(Keys.W))
        {
            changeX = Speed * (float)Math.Sin(TankRotation) * gametime;
            changeY = Speed * (float)Math.Cos(TankRotation) * gametime;
            if (PlayerRect.Intersects(Rect))
            {
                changeX -= 1;
                changeY += 1;
            }
        }

        TankPosition.X += changeX;
        TankPosition.Y -= changeY;

        if (state.IsKeyDown(Keys.S))
        {
            changeXX = Speed * (float)Math.Sin(TankRotation) * gametime;
            changeYY = Speed * (float)Math.Cos(TankRotation) * gametime;
            if (PlayerRect.Intersects(Rect))
            {
                changeXX += 1;
                changeYY -= 1;
            }
        }
        TankPosition.X -= changeXX;
        TankPosition.Y += changeYY;

        TankPosition.X = Single.Clamp(TankPosition.X, 0 + PlayerRect.Height / 2.3f, maxX - PlayerRect.Height / 2.3f);
        TankPosition.Y = Single.Clamp(TankPosition.Y, 0 + PlayerRect.Height / 3f, maxY - PlayerRect.Height / 2f);
    }
}