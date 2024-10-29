using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGamesa;

public class Sprite
{
    public Texture2D texture;

    public float Speed;

    public Sprite(Texture2D texture, float speed)
    {
        this.texture = texture;
        Speed = speed;
    }
}