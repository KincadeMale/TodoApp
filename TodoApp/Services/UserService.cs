using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    internal class UserService : Data.TODOEntities
    {
        public int CreateUser(string username, string password)
        {
            base.Users.Add(new Data.User()
            {
                UserName = username,
                Password = password,
                Active = true
            });

            return base.SaveChanges();
        }
    }
}
