using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Level
    {
        public int BoxCount {  get; set; }
        public int TargetCount {  get; set; }
        public List<Sprite> Sprites { get; set; }
    }
}
