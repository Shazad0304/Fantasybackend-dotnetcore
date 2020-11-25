using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
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

        public Points addPoints(Points p)
        {
            this.context.Add(p);
            this.context.SaveChanges();
            return p;
        }


    }
}
