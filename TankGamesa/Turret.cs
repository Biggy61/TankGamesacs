using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Turret : Sprite
{
    public static float TurretRotation;
    public static Rectangle BulletRect
    {
        get { return new Rectangle((int)Player.TankPosition.X,(int)Player.TankPosition.Y, 10, 10); }
    }


    public Turret(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
        
    }

    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed)
    {
        KeyboardState state = Keyboard.GetState();
        float tankRotationSpeed = tankRotSpeed;


        if (state.IsKeyDown(Keys.D))
        {
            TurretRotation += tankRotationSpeed * gametime;
            //TankPosition.X += 1;
        }

        if (state.IsKeyDown(Keys.A))
        {
            TurretRotation -= tankRotationSpeed * gametime;
            //TankPosition.X -= 1;
        }
        
        if (state.IsKeyDown(Keys.W))
        {
            TankPosition.X += Speed * (float)Math.Sin(TurretRotation) * gametime;
            TankPosition.Y -= Speed * (float)Math.Cos(TurretRotation) * gametime;
            //TankPosition.Y -= 1;
        }
        
        if (state.IsKeyDown(Keys.S))
        {
            TankPosition.X -= Speed * (float)Math.Sin(TurretRotation) * gametime;
            TankPosition.Y += Speed * (float)Math.Cos(TurretRotation) * gametime;
            //TankPosition.Y += 1;
        }

}