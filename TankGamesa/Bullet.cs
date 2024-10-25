using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Bullet : Sprite
{
    public static Vector2 Point = Player.TankPosition;
    static MouseState mouse = Mouse.GetState();
    
   
    
    
    Vector2 MousePosition = new Vector2(mouse.X, mouse.Y);
    public void ShootBullet(Vector2 BulletPosition)
    {
       Rectangle rect =  new Rectangle((int)BulletPosition.X, (int)BulletPosition.Y , 100, 100);
    }


    public Bullet(Texture2D texture, Vector2 position, float speed, Vector2 direction) : base(texture, position, speed)
    {
    }

    // public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
    //     {
    //         spriteBatch.Draw(texture, position, Color.White);
    //     }

  
    
}