using FantasyBackend.DbContextFantasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class PointsRepo
    {
        FantasyCon context;

        public PointsRepo(FantasyCon context)
        {
            this.context = context;
        }
    }
}
