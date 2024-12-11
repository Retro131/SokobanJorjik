using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Levels
    {
        public int Id { get; set; }
        public int BoxCount { get; set; }
        public int TargetCount { get; set; }
        public ICollection<Results>? Results { get; set; }
        public Levels()
        {
            Results = new List<Results>();
        }
    }
}
