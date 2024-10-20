using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGamesa;

public class Bullet : Sprite
{
    public float speed;
    public Rectangle Rect
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 25, 25);
        }
    }
    public Bullet(Texture2D texture, Vector2 position, float speed) : base(texture, position)
    {
        this.speed = speed;
    }
}