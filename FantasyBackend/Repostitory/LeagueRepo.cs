using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class LeagueRepo
    {
        FantasyCon context;

        public LeagueRepo(FantasyCon context)
        {
            this.context = context;
        }

        public List<League> getAll(Guid id)
        {
            return this.context.Leagues.Where(x => x.userId == id).ToList();
        }

        public League addLeague(League l)
        {
            this.context.Leagues.Add(l);
            this.context.SaveChanges();
            return l;
        }
    }
}
