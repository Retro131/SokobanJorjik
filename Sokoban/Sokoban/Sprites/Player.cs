using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Player : Sprite
    {
        public Player(Texture2D texture, Vector2 position, Color color, float speed) : base(texture, position, color, speed) { }
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
                if(Velocity.X > 0 && IsTouchingLeft(sprite) ||
                        Velocity.X < 0 && IsTouchingRight(sprite))
                    Velocity.X = 0;
                if(Velocity.Y >  0 && IsTouchingTop(sprite) ||
                        Velocity.Y < 0 && IsTouchingBottom(sprite))
                    Velocity.Y = 0;
            }
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity.X -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity.X += speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                Velocity.Y -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                Velocity.Y += speed;
        }
        public override float GetPriority() => 0.1f;
        public override string ToString() => "Player.png";

    }
}
