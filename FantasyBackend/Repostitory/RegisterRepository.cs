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


        public Register Insert(Register user)
        {
            context.Register.Add(user);
            context.SaveChanges();
            return user;
        }

        public Register FindByEmailandPass(string email,string pass)
        {
            return this.context.Register.FirstOrDefault(x => x.Email == email && x.Password == pass);
        }

        public bool Existed(string email)
        {
            return !(this.context.Register.FirstOrDefault(x => x.Email == email) == null);
        }
    }
}
