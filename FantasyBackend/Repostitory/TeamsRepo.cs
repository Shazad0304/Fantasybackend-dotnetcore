using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class TeamsRepo
    {
        FantasyCon context;

        public TeamsRepo(FantasyCon context)
        {
            this.context = context;
        }

        public UserTeams AddTeam(UserTeams t)
        {
            context.UserTeams.Add(t);
            context.SaveChanges();
            return t;
        }

        public void DeleteUserTeam(Guid id)
        {
            context.UserTeams.RemoveRange(context.UserTeams.Where(x => x.userId == id));
            context.SaveChanges();
        }

        public List<Players> getmyTeam(Guid id)
        {
            List<Players> teams = (from p in context.UserTeams
                                    join e in context.Players
                                    on p.PlayerId equals e.Id
                                    where p.userId == id
                                    select e).ToList();

            return teams;
        }

    }
}
