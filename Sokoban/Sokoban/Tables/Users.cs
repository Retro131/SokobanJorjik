using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Results> Results { get; set; }
        public Users()
        {
            Results = new List<Results>();
        }
    }
}
