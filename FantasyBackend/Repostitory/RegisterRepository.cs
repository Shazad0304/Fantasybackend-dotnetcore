using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class RegisterRepository
    {
        FantasyCon context;

        public RegisterRepository(FantasyCon context)
        {
            this.context = context;
        }


        public Register insert(Register r)
        {
            context.Register.Add(r);
            context.SaveChanges();
            return r;
        }

        public Register findbyemailandpass(string email,string pass)
        {
            return this.context.Register.FirstOrDefault(x => x.Email == email && x.Password == pass);
        }

        public bool Existed(string email)
        {
            return !(this.context.Register.FirstOrDefault(x => x.Email == email) == null);
        }
    }
}
