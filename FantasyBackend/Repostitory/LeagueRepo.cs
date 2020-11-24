using FantasyBackend.DbContextFantasy;
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
    }
}
