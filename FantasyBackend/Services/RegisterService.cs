using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class RegisterService
    {
        RegisterRepository rp;

        public RegisterService(FantasyCon context)
        {
            rp = new RegisterRepository(context);
        }

        public Dictionary<string, object> Add(Register r)
        {
            Dictionary<string, object> resp = new Dictionary<string, object>();
            if (rp.Existed(r.Email))
            {
                resp.Add("error", "Already Existed");
                return resp;
            }
            else
            {
                resp.Add("success", rp.Insert(r));
                return resp;
            }

        }

        public Register Login(Login r)
        {
            Register obj = rp.FindByEmailandPass(r.Email, r.Password);
            if (obj == null)
            {
                return null;
            }
            else
            {
                return obj;
            }

        }


    }
}
