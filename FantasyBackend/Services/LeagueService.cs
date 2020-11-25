using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class LeagueService
    {
        LeagueRepo rp;

        public LeagueService(FantasyCon context)
        {
            rp = new LeagueRepo(context);
        }

        public List<League> getAll(String id)
        {
            
            return this.rp.getAll(Guid.Parse(id));
        }

        public League add(League l)
        {
            return this.rp.addLeague(l);
        }
    }
}
