using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban.Sprites
{
    public class PlayerCreator : Player
    {
        Texture2D boxTexture;
        Texture2D targetTexture;
        Texture2D wallTexture;
        public PlayerCreator(Texture2D texture, Vector2 position, Color color, Level level, List<Texture2D> texture2Ds) : base(texture, position, color, level)
        {
            boxTexture = texture2Ds[0];
            wallTexture = texture2Ds[1];
            targetTexture = texture2Ds[2];
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            var newPos = GetNewPosition();
            Position = newPos;
            DropSprite();
        }
        private void DropSprite()
        {
            controlKeys.Update();
            if (controlKeys.IsKeyWasPressed(Keys.I))
                _level.Sprites.Add(new Wall(wallTexture, Position, Color.White));
            else if (controlKeys.IsKeyWasPressed(Keys.O))
            {
                _level.BoxCount++;
                _level.Sprites.Add(new Box(boxTexture, Position, Color.White));
            }
            else if (controlKeys.IsKeyWasPressed(Keys.P))
            {
                _level.TargetCount++;
                _level.Sprites.Add(new Target(targetTexture, Position, Color.White));
            }
        }
    }
}
