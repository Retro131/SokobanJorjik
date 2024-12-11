using System;
using System.Linq;
namespace Sokoban
{
    public static class DbContextExtensions
    {
        public static void Add(this DBContext dBContext, Level level)
        {
            if(level.TotalSteps == 0)
            {
                Levels levels = new Levels(level);
                dBContext.Add(levels);
            }
            else
            {
                Results results = new Results();
                Levels levels = dBContext.Levels.FirstOrDefault(x => x.Id == level.Id);
                Users users = dBContext.Users.FirstOrDefault(x => x.Name == UserName.getInstance());
                results.date = DateTime.Now;
                results.Steps = level.TotalSteps;
                results.Levels = levels;
                results.Users = users;
                dBContext.Add(results);
                users.Results.Add(results);
                levels.Results.Add(results);
            }
            dBContext.SaveChanges();
        }
        public static void Add(this DBContext dBContext, string name)
        {
            Users users = new Users();
            users.Name = name;
            dBContext.Add(users);
            dBContext.SaveChanges();
        }

    }
}
