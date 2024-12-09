using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    public class Box : Sprite
    {
        private bool _isMoveable = true;
        public Box(Texture2D texture, Vector2 position, Color color) : base(texture, position, color) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (IsOnTarget(sprites))
            {
                _isMoveable = false;
                Color = Color.Gray;
            }
        }
        public override bool TryMove(Vector2 Delta, List<Sprite> sprites)
        {
            if (!_isMoveable)
                return false;
            var newPos = Delta + Position;
            foreach (var sprite in sprites)
            {
                if (sprite == this || sprite is Target)
                    continue;
                if (IsCollision(newPos, sprite))
                    return false;
            }
            Position = newPos;
            return true;
        }
        public override bool IsOnTarget(List<Sprite> sprites)
        {
            foreach(var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (IsCollision(Position,sprite) && sprite is Target)
                    return true;
            }
            return false;
        }
        public override float GetPriority() => 0.2f;
        public override string ToString() => "Box.png";

    }
}
