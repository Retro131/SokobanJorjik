using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    public class Wall : Sprite
    {
        public Wall(Texture2D texture, Vector2 position, Color color, float speed, float weight) : base(texture, position, color, speed, weight) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }
        public override float GetPriority() => 0.5f;
        public override string ToString() => "Wall.png";
    }
}
