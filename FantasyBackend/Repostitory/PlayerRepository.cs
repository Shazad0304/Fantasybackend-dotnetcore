using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class PlayerRepository
    {
        FantasyCon context;

        public PlayerRepository(FantasyCon context)
        {
            this.context = context;
        }

        public Players AddPlayer(Players player)
        {
            this.context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        public List<Players> GetAll()
        {
            return this.context.Players.ToList();
        }

        public List<Players> GetPlayersByTeam(string Team)
        {
            return this.context.Players.Where(x => x.Team == Team).ToList();
        }

        public bool IsExisted(Players player)
        {
            return !(context.Players.FirstOrDefault(x => x.Name == player.Name && x.Team == player.Team) == null);
        }

    }
}
