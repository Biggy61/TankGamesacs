using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Bullet : Sprite
{
    public static Vector2 Point = Player.TankPosition;
    static MouseState mouse = Mouse.GetState();
    public Rectangle BulletRect(Vector2 BulletPosition)
    {
        return new Rectangle((int)BulletPosition.X, (int)BulletPosition.Y , 100, 100);
    }


    public Bullet(Texture2D texture, Vector2 position, float speed, Vector2 direction) : base(texture, position, speed)
    {
    }
    

  
    
}