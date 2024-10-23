using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGamesa;

public class Bullet : Sprite
{
    public static Vector2 Point = Player.TankPosition;
    public static Rectangle BulletRect
    {
        get { return new Rectangle((int)Point.X / 2, (int)Point.Y + 5, 25, 25); }
    }

    public Bullet(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
    {
    }
}