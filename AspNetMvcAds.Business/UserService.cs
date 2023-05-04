using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvcAds.Business
{  
    public interface IUserService
    {
        public User GetUserByUserNameOrEmail(string username, string email);


    }
    public class UserService:IUserService
    {

        public AppDbContext Db { get; }

        public UserService(AppDbContext db)
        {

            Db = db;
        }

        public User GetUserByUserNameOrEmail (string username,string email )
        {
            return Db.Users.FirstOrDefault(e => e.Name == username || e.Email == email);
        }
       


    }
}

       
       



    

