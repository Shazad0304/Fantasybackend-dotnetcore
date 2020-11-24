using FantasyBackend.DbContextFantasy;
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

    }
}
