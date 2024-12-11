using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class UserName
    {
        private static string Name;

        private UserName()
        { }

        public static string getInstance()
        {
            Random random = new Random();
            if (Name == null)
                Name = "guest" + $"{random.NextDouble}";
            return Name;
        }
    }
}
