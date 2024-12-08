using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sokoban
{
    public class Box : Sprite
    {
        private float _startWeight;
        public Box(Texture2D texture, Vector2 position, Color color, float speed, float weight) : base(texture, position, color, speed, weight) 
        {
            _startWeight = weight;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (sprite is not Player && (Velocity.X > 0 && IsTouchingLeft(sprite) ||
                        Velocity.X < 0 && IsTouchingRight(sprite)))
                    Weight = sprite.Weight;
                if (sprite is not Player && (Velocity.Y > 0 && IsTouchingTop(sprite) ||
                        Velocity.Y < 0 && IsTouchingBottom(sprite)))
                    Weight = sprite.Weight;
            }
            Weight = _startWeight;
            Position += Velocity;
            Velocity = Vector2.Zero;
        }
        public override float GetPriority() => 0.2f;
        public override string ToString() => "Box.png";

    }
}
