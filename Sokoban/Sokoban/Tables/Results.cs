using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sokoban
{
    public class Results
    {
        public int Id { get; set; }
        public Users Users { get; set; }
        public Levels Tests { get; set; }
        public int Steps { get; set; }
        public int date { get; set; }
    }
}
