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

        public object get()
        {
            return this.rp.getAllWithoutId();
        }

        public League add(League l)
        {
            return this.rp.addLeague(l);
        }

        public object join(String userid, String Leagueid)
        {
            return this.rp.joinleague(new UserJoinLeagues() 
            {UserId=Guid.Parse(userid),LeagueId= Guid.Parse(Leagueid) });
        }

        public object getjoinedleagues(String id)
        {
            return this.rp.getmyjoinleagues(Guid.Parse(id));
        }
    }
}
