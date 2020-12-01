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
        LeagueRepository rp;

        public LeagueService(FantasyCon context)
        {
            rp = new LeagueRepository(context);
        }

        public List<League> GetAll(String id)
        {
            
            return this.rp.GetAll(Guid.Parse(id));
        }

        public object Get()
        {
            return this.rp.GetAllWithoutId();
        }

        public League Add(League l)
        {
            return this.rp.AddLeague(l);
        }

        public object Join(String userid, String Leagueid)
        {
            return this.rp.JoinLeague(new UserJoinLeagues() 
            {UserId=Guid.Parse(userid),LeagueId= Guid.Parse(Leagueid) });
        }

        public object GetJoinedLeagues(String id)
        {
            return this.rp.GetMyJoinLeagues(Guid.Parse(id));
        }

        public bool Exists(String userid,String leagueid)
        {
            return this.rp.Existed(Guid.Parse(userid), Guid.Parse(leagueid));
        }

        public object GetPointsByLeague(String id)
        {
            return this.rp.GetLeagueScores(Guid.Parse(id));
        }
    }
}
