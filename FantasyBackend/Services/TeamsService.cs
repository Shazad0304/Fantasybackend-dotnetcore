using FantasyBackend.DbContextFantasy;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class TeamsService
    {
        TeamsRepo rp;

        public TeamsService(FantasyCon context)
        {
            rp = new TeamsRepo(context);
        }
    }
}
