using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class PlayerService
    {
        PlayerRepository rp;

        public PlayerService(FantasyCon context)
        {
            rp = new PlayerRepository(context);
        }


        public object AddPlayer(Players player)
        {
            return rp.IsExisted(player) ? null : rp.AddPlayer(player);
        }

        public object GetPlayerByTeam(string team)
        {
            return rp.GetPlayersByTeam(team);
        }

        public object All()
        {
            return this.rp.GetAll();
        }
    }
}

