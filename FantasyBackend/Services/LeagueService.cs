using FantasyBackend.DbContextFantasy;
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
    }
}
