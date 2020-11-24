using FantasyBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.DbContextFantasy
{
    public class FantasyCon : DbContext
    {
        public FantasyCon(DbContextOptions<FantasyCon> options) : base(options)
        {
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<UserTeams> UserTeams { get; set; }

    }
}
