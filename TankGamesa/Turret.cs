using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Turret : Sprite
{
    public static Vector2 TurretPosition = Vector2.Zero;
    public static float TurretRotation;

    public Rectangle TurretRect
    {
        get { return new Rectangle((int)Player.TankPosition.X, (int)Player.TankPosition.Y, 50, 50); }
    }


    public Turret(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
        Speed = speed;
    }

    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed)
    {
        KeyboardState state = Keyboard.GetState();
        float turretRotationSpeed = tankRotSpeed;


        if (state.IsKeyDown(Keys.Right))
        {
            TurretRotation += turretRotationSpeed * gametime;
            //TankPosition.X += 1;
        }

        if (state.IsKeyDown(Keys.Left))
        {
            TurretRotation -= turretRotationSpeed * gametime;
            //TankPosition.X -= 1;
        }

        if (state.IsKeyDown(Keys.Up))
        {
            Player.TankPosition.X += Speed * (float)Math.Sin(TurretRotation) * gametime;
            Player.TankPosition.Y -= Speed * (float)Math.Cos(TurretRotation) * gametime;
            //TankPosition.Y -= 1;
        }

        if (state.IsKeyDown(Keys.Down))
        {
            Player.TankPosition.X -= Speed * (float)Math.Sin(TurretRotation) * gametime;
            Player.TankPosition.Y += Speed * (float)Math.Cos(TurretRotation) * gametime;
            //TankPosition.Y += 1;
        }
        
        TurretPosition.X = Single.Clamp(TurretPosition.X, 0 + TurretRect.Width, maxX - TurretRect.Width);
        TurretPosition.Y = Single.Clamp(TurretPosition.Y, 0 + TurretRect.Height / 2f, maxY - TurretRect.Height / 2f);

    }
}