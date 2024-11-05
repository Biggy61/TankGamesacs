using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGamesa;

public class Bullet
{
    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _direction;
    private float _speed;
    public float LifeTime { get; private set; }
    //public static Vector2 Point = Player.TankPosition;
    public static Vector2 Position = new Vector2(Turret.Rect.X, Turret.Rect.Y);
    static MouseState mouse = Mouse.GetState();
    public Rectangle BulletRect
    {
        get { return new Rectangle((int)Position.X, (int)Position.Y, 10, 10); }
    }

    public Bullet(Texture2D texture, Vector2 position, Vector2 direction, float speed, float lifeTime)
    {
        _texture = texture;
        _position = position;
        _direction = direction;
        _speed = speed;
        LifeTime = 0f;
    }
    public void Update(float deltaTime ,Rectangle enemy)
        {
            if (BulletRect.Intersects(enemy))
            {
                Console.WriteLine("Bohata");
            }
            _position += _direction * _speed * deltaTime;
            LifeTime += deltaTime;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    
}