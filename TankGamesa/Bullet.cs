using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Bullet : Sprite
{
    public static Vector2 Point = Player.TankPosition;
    static MouseState mouse = Mouse.GetState();
    Vector2 MousePosition = new Vector2(mouse.X, mouse.Y);
    public Rectangle BulletRect
    {
        get { return new Rectangle((int)Point.X / 2, (int)Point.Y + 5, 25, 25); }
    }

    public Bullet(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
    }
    
    public void Shoot(Texture2D bullettexture)
    {
        Bullet bullet = new Bullet(bullettexture, new Vector2(BulletRect.X, BulletRect.Y), Speed);

    }
}