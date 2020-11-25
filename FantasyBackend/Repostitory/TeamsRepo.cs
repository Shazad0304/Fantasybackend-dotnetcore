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
            this.context.Add(t);
            this.context.SaveChanges();
            return t;
        }

    }
}
