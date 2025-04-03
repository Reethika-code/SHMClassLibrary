using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHMClassLibrary.Data;
using SHMClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;


namespace SHMClassLibrary.Repository
{

   public class UserRepository
    {
        public void AddUsers(User newuser)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(newuser);
                context.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = context.Users.ToList<User>();
                return users;
            }
        }


        public List<User> GetUsersByName(string UserName)
        {
            using (var context = new AppDbContext())
            {

                var users = context.Users.Where(a => a.Name == UserName).ToList<User>();
                foreach (var res in users)
                {
                    Console.WriteLine(res.ToString());
                }
                return users;
            }
        }
        
        public User GetUserById(int UserId)
        {
            using(var context=new AppDbContext())
            {
                return context.Users.Find(UserId);
            }
        }
        public List<User> GetUserByRole(string role)
        {
            using(var context=new AppDbContext())
            {
                return context.Users.Where(u => u.Role == role).ToList();
            }
        }


        public static void UpdateUser(int UserId, string newName, string newEmail, string newContact)
        {
            using (var dbContext = new AppDbContext())
            {
                var user = dbContext.Users.Find(UserId);
                if (user != null)
                {
                    user.Name = newName;
                    user.Email = newEmail;
                    user.ContactNumber = newContact;
                    dbContext.SaveChanges();

                }
            }
        }



        public void DeleteUser(int userId)
        {
            using (var dbContext = new AppDbContext())
            {
                var user = dbContext.Users.Find(userId);
                if (user != null)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
