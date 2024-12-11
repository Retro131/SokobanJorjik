using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    public class LevelManager
    {
        public LinkedList<Level> Levels;
        public LevelManager(ContentManager contentManager)
        {
            var index = 0;
            Levels = new LinkedList<Level>();
            foreach (var level in DefaultLevelsInGrid.MapsForLevels)
            {
                Levels.AddLast(new Level(index, level,contentManager));
                index++;
            }
            foreach(var level in Levels)
            {
                Game1.db.AddToDb(level);
            }
        }
        public void AddLevel() { }
        public void RemoveLevel() { }
    }
}
