using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class UserName
    {
        private static UserName instance;

        private UserName()
        { }

        public static UserName getInstance()
        {
            if (instance == null)
                instance = new UserName();
            return instance;
        }
    }
}
