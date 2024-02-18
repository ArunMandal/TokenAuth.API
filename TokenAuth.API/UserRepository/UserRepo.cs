using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenAuth.API.Data;
using TokenAuth.API.Models;

namespace TokenAuth.API.UserRepository
{
    public class UserRepo:IDisposable
    {

        ApplicationDbConnect dbConnect = new ApplicationDbConnect();

       

        public User ValidateUser(string username, string password)
        {

          return  dbConnect.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }


        public void Dispose()
        {
            dbConnect.Dispose();
        }

    }
}