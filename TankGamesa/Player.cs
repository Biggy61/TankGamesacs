using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class Player : Sprite
{
    public static Vector2 TankPosition = Vector2.Zero;
    public float Speed;
    public static float TankRotation;

    public Rectangle Rect
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 100, 100);
        }
    }
    public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position)
    {
        this.Speed = speed;
    }

    public void Move(float maxX, float maxY, float gametime, float TankRotSpeed)
    {
           KeyboardState state = Keyboard.GetState();
           float tankRotationSpeed = TankRotSpeed;
           float DT = gametime;
           Console.WriteLine(DT);
                    if (state.IsKeyDown(Keys.D))
                    {
                        TankPosition.X += Speed;
                        TankRotation += tankRotationSpeed * DT;
                    }
           
                    if (state.IsKeyDown(Keys.A))
                    {
                        TankPosition.X -= Speed;
                        TankRotation -= tankRotationSpeed * DT;
                    }
           
                    if (state.IsKeyDown(Keys.W))
                    {
                        TankPosition.Y -= Speed;
                        TankPosition.X += Speed * (float)Math.Sin(TankRotation) * DT;
                        TankPosition.Y -= Speed * (float)Math.Cos(TankRotation) * DT;
                    }
           
                    if (state.IsKeyDown(Keys.S))
                    {
                        TankPosition.Y += Speed;
                        TankPosition.X -= Speed * (float)Math.Sin(TankRotation) * DT;
                        TankPosition.Y += Speed * (float)Math.Cos(TankRotation) * DT;
                    }
                    TankPosition.X = Single.Clamp(TankPosition.X, 0, maxX);
                    TankPosition.Y = Single.Clamp(TankPosition.Y, 0, maxY);

    }

       
    
     
    
}

