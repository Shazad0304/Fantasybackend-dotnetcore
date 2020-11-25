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
        PlayerRepo rp;

        public PlayerService(FantasyCon context)
        {
            rp = new PlayerRepo(context);
        }


        public object AddPlayer(Players player)
        {
            return rp.isExisted(player) ? null : rp.addPlayer(player);
        }

        public object getPlayerbyteam(string team)
        {
            return rp.getPlayersbyTeam(team);
        }

        public object all()
        {
            return this.rp.getAll();
        }
    }
}

