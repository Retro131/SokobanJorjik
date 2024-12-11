using System.Collections.Generic;

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
        public Levels(Level level)
        {
            BoxCount = level.BoxCount;
            TargetCount = level.TargetCount;
            Results = new List<Results>();
        }
    }
}
