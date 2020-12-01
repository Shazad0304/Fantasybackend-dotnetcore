using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class TeamsRepository
    {
        FantasyCon context;

        public TeamsRepository(FantasyCon context)
        {
            this.context = context;
        }

        public UserTeams AddTeam(UserTeams team)
        {
            context.UserTeams.Add(team);
            context.SaveChanges();
            return team;
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
