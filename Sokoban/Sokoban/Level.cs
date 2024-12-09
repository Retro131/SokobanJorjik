using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Level
    {
        public int Id {  get; set; }
        public int BoxCount {  get; set; }
        public int TargetCount {  get; set; }
        public List<Sprite> Sprites { get; set; }
        public Level(int Id, int BoxCount, int TargetCount, List<Sprite> sprites) 
        {
            this.Id = Id;
            this.BoxCount = BoxCount;
            this.TargetCount = TargetCount;
            this.Sprites = sprites;
        }
    }
}
