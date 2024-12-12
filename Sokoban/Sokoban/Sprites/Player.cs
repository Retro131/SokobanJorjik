using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Player : Sprite
    {
        protected Level _level;
        private Vector2 _previousPosition;
        protected InputHandler controlKeys = new InputHandler();

        public Player(Texture2D texture, Vector2 position, Color color, Level level) : base(texture, position, color)
        {
            _previousPosition = position;
            _level = level;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            var newPos = GetNewPosition();
            if (_previousPosition != Position)
                _level.TotalSteps++;
            if (TryMove(newPos, sprites))
            {
                _previousPosition = Position;
                Position = newPos;
            }
        }
        public override bool TryMove(Vector2 newPos, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this || sprite is Target)
                    continue;
                if (IsCollision(newPos, sprite))
                {
                    if (sprite is Box)
                    {
                        var deltaMove = newPos - Position;
                        if (sprite.TryMove(deltaMove, sprites))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            return true;
        }
        protected Vector2 GetNewPosition()
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

        public override float GetPriority() => 0.1f;
        public override string ToString() => "Player.png";

    }
}
