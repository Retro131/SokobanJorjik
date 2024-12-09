using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class LevelManager
    {
        public static readonly List<Level> DefaultLevels;
        public List<Level> PlayerLevels;
        static LevelManager()
        {
            DefaultLevels = new List<Level>()
            {

            };
        }
        public void AddLevel() { }
        public void RemoveLevel() { }
    }
}
