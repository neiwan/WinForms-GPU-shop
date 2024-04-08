using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using kis.DB_Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;

namespace kis.Controllers
{
    public class UserController
    {
        private int cur_user_id { get; set; }

        private VidContext db;
        public UserController(int id, VidContext db)
        {
            cur_user_id = id;
            this.db = db;
        }
        public string[,] Get_Users()
        {
            string[,] table_content;
            table_content = new string[db.Users.Count(), 3];
            foreach (var item in db.Users)
            {
                table_content[item.UserId - 1, 0] = item.UserId.ToString();
                table_content[item.UserId - 1, 1] = item.UserName[0];
                table_content[item.UserId - 1, 2] = item.UserRole[0];
            }
            return table_content;
        }
        public string Get_Role()
        {
            var user = db.Users.Where(u => u.UserId == cur_user_id);
            string role = user.ToList()[0].UserRole[0];
            return role;
        }
        public string[] Get_Values()
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == cur_user_id);
            return [user.UserName[0].ToString(), user.UserCity[0].ToString(), user.UserAdres[0].ToString(), user.UserPassword[0].ToString(), user.UserLogin[0].ToString()];
        }
        public void UpdateUserRole(int userId, string[] newRole)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.UserRole = newRole.ToList();
                db.SaveChanges();
            }
        }
        public void UpdateUsername(int userId, string[] newUsername)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.UserName = newUsername.ToList();
                db.SaveChanges();
            }
        }
        public void UpdateValues(string[] name, string[] city, string[] adres, string[] password, string[] login)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == cur_user_id);
            if (user != null && IsLoginUnique(login.ToList()) || user != null && user.UserName[0] == login[0])
            {
                user.UserName = name.ToList();
                user.UserCity = city.ToList();
                user.UserAdres = adres.ToList();
                user.UserPassword = password.ToList();
                user.UserLogin = login.ToList();
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("This login already exists!");
            }
        }
        public bool IsLoginUnique(List<string> login)
        {
            return !db.Users.Any(u => u.UserLogin == login);
        }
    }
}
