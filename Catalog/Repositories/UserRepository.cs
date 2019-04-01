using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class UserRepository
    {
        private static List<User> users = null;
        public UserRepository()
        {
            if (users == null)
            {
                users = new List<User>();
                users.Add(new User { Id=new Guid(), UserName="Chetan", Password="chetan"});
                users.Add(new User { Id = new Guid(), UserName = "Kapil", Password = "kapil" });
                users.Add(new User { Id = new Guid(), UserName = "Nishant", Password = "nishant" });
            }
        }

        //public bool Authorized(string userName)
        //{
        //    User user = users.FirstOrDefault(u => u.UserName == userName);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
