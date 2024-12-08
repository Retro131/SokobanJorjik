using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    public class Sprite
    {
        public static int SpriteSize = 50;
        protected Texture2D _texture { get; }
        public Vector2 Position;
        public Color Color { get; set; }
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, SpriteSize, SpriteSize);
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            Position = position;
            Color = color;
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites) { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color, 0, Vector2.Zero, 1.1f, SpriteEffects.None, GetPriority());
        }
        public virtual float GetPriority() => 0;
        public bool IsCollision(Vector2 newPosition, Sprite other)
        {
            var newHitboX = new Rectangle((int)newPosition.X, (int)newPosition.Y, SpriteSize, SpriteSize);

            return newHitboX.Intersects(other.HitBox);
        }
    }
}
