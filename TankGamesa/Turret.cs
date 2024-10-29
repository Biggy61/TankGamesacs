using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Turret : Sprite
{
    public static float TurretRotation;
    KeyboardState state = Keyboard.GetState();
     MouseState mouse = Mouse.GetState();
    public static Rectangle TurretRect
    {
        get { return new Rectangle((int)Player.TankPosition.X, (int)Player.TankPosition.Y + 10, 50, 100); }
    }
    public static Vector2 Rect = new Vector2(TurretRect.X, TurretRect.Y);
    public Turret(Texture2D texture, float speed) : base(texture, speed)
    {
    }

    public void Move(float maxX, float maxY, float gametime, float tankRotSpeed)
    {
        Player.TankPosition.X = Single.Clamp( Player.TankPosition.X, 0 + TurretRect.Width, maxX - TurretRect.Width);
        Player.TankPosition.Y = Single.Clamp( Player.TankPosition.Y, 0 + TurretRect.Height / 2f, maxY - TurretRect.Height / 2f);

    }
}