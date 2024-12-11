using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    public class Sprite
    {
        public static int SpriteSize = 50;
        protected Texture2D _texture { get; }
        public Vector2 Position {  get; set; }
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
        public virtual bool TryMove(Vector2 newPos, List<Sprite> sprites)
        {
            var canMove = true;
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (IsCollision(newPos, sprite))
                {
                    canMove = false;
                    break;
                }
            }
            return canMove;
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites) { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color, 0, Vector2.Zero, 1.1f, SpriteEffects.None, GetPriority());
        }
        public virtual bool IsOnTarget(List<Sprite> sprites)
        {
            return false;
        }
        public virtual float GetPriority() => 0;
        public bool IsCollision(Vector2 newPosition, Sprite other)
        {
            var newHitBox = new Rectangle((int)newPosition.X, (int)newPosition.Y, SpriteSize, SpriteSize);

            return newHitBox.Intersects(other.HitBox);
        }
    }
}
