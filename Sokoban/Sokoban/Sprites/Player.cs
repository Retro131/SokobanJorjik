using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Player : Sprite
    {
        public Player(Texture2D texture, Vector2 position, Color color, float speed, float weight) : base(texture, position, color, speed, weight) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (Velocity.X > 0 && IsTouchingLeft(sprite) ||
                        Velocity.X < 0 && IsTouchingRight(sprite))
                    Velocity.X = sprite.Velocity.X = Velocity.X * CalculateForPushingObjects(sprite);
                if (Velocity.Y > 0 && IsTouchingTop(sprite) ||
                        Velocity.Y < 0 && IsTouchingBottom(sprite))
                    Velocity.Y = sprite.Velocity.Y = Velocity.Y * CalculateForPushingObjects(sprite);
            }
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity.X -= Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity.X += Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                Velocity.Y -= Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                Velocity.Y += Speed;
        }
        private float CalculateForPushingObjects(Sprite sprite)
        {
            if(sprite.Weight == 0)
            {
                return 1;
            }
            else if (sprite.Weight < 0)
            {
                return 0f;
            }
            return Weight/sprite.Weight;
        }
        public override float GetPriority() => 0.1f;
        public override string ToString() => "Player.png";

    }
}
