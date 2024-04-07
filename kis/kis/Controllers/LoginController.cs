using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kis.DB_Classes;

namespace kis.Controllers
{
    public class LoginController
    {
        private int cur_user_id { get; set; }
        private VidContext db = new VidContext();
        public bool Login(string login, string pwd)
        {
            var user_login = db.Users.Where(u => u.UserPassword[0] == pwd && u.UserLogin[0] == login);
            if (user_login.Count() != 0)
            {
                var users = user_login.ToList();
                cur_user_id = users[0].UserId;
                Console.WriteLine($"User logged in, id - {cur_user_id}");
                return true;
            }
            else
            {
                Console.WriteLine("User not found");
                return false;
            }
        }
        public int GetID()
        {
            return cur_user_id;
        }
        public VidContext GetDB()
        {
            return db;
        }
    }
}
