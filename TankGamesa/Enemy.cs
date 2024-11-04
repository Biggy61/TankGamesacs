using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TankGamesa;

public class
    Enemy : Sprite
{
    public static Vector2 EnemyPosition = new Vector2(250, 250);
    readonly float Speed;
    public float TankRotation;
    public double Hp;
    public Rectangle EnemyRect => new((int)EnemyPosition.X, (int)EnemyPosition.Y + 10, 50, 100);

    public Enemy(Texture2D texture, float speed, double hp) : base(texture, speed)
    {
        Speed = speed;
        Hp = hp;
    }


    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed)
    {
        KeyboardState state = Keyboard.GetState();
        float tankRotationSpeed = tankRotSpeed;
        Random rnd = new Random();
        int rand = rnd.Next(1, 10);
        if (rand <= 2)
        {
            TankRotation += tankRotationSpeed * gametime;
        }

        if (rand is > 2 and <= 4)
        {
            TankRotation -= tankRotationSpeed * gametime;
        }

        if (rand is > 4 and <= 6)
        {
            EnemyPosition.X += Speed * (float)Math.Sin(TankRotation) * gametime;
            EnemyPosition.Y -= Speed * (float)Math.Cos(TankRotation) * gametime;
        }

        if (rand is > 6 and <= 8)
        {
            EnemyPosition.X -= Speed * (float)Math.Sin(TankRotation) * gametime;
            EnemyPosition.Y += Speed * (float)Math.Cos(TankRotation) * gametime;
        }


        EnemyPosition.X = Single.Clamp(EnemyPosition.X, 0 + EnemyRect.Height / 2.3f, maxX - EnemyRect.Height / 2.3f);
        EnemyPosition.Y = Single.Clamp(EnemyPosition.Y, 0 + EnemyRect.Height / 3f, maxY - EnemyRect.Height / 2f);
    }
}