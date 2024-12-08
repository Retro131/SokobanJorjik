using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Player : Sprite
    {
        private InputHandler controlKeys = new InputHandler();

        public Player(Texture2D texture, Vector2 position, Color color) : base(texture, position, color) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            var newPos = Move();
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
            Position = canMove ? newPos : Position;
        }

        public Vector2 Move()
        {
            var newPos = Position;
            controlKeys.Update();
            if (controlKeys.IsKeyWasPressed(Keys.A))
                newPos.X -= SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.D))
                newPos.X += SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.W))
                newPos.Y -= SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.S))
                newPos.Y += SpriteSize;
            return newPos;
        }
        private bool CanMove(Sprite sprite)
        {
            return sprite is Box;
        }
        public override float GetPriority() => 0.1f;
        public override string ToString() => "Player.png";

    }
}
