﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Player : Sprite
    {
        private InputHandler controlKeys = new InputHandler();

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
        }

        public void Move()
        {
            controlKeys.Update();
            if (controlKeys.IsKeyWasPressed(Keys.A))
                Position.X -= SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.D))
                Position.X += SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.W))
                Position.Y -= SpriteSize;
            else if (controlKeys.IsKeyWasPressed(Keys.S))
                Position.Y += SpriteSize;
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
        private bool CanMove(Sprite sprite)
        {
            return sprite is Box;
        }
        public override float GetPriority() => 0.1f;
        public override string ToString() => "Player.png";

    }
}
