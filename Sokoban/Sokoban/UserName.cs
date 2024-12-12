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

        public static string setInstance(string name)
        {
            Random random = new Random();
            if (Name == null)
                if(name == null)
                    Name = "guest" + $"{random.NextInt64()}";
                else
                    Name = name;

            return Name;
        }
        public static string getInstance()
        {
            return Name;
        }
    }
}
