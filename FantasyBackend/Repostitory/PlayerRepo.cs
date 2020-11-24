using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class PlayerRepo
    {
        FantasyCon context;

        public PlayerRepo(FantasyCon context)
        {
            this.context = context;
        }

        public Players addPlayer(Players p)
        {
            this.context.Players.Add(p);
            context.SaveChanges();
            return p;
        }

        public bool isExisted(Players p)
        {
            return !(context.Players.FirstOrDefault(x => x.Name == p.Name && x.Team == p.Team) == null);
        }

    }
}
