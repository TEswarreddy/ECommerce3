using ECommerce3.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce3.DataLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        ECommerceEntities1 context;
        public UserRepository()
        {
            context = new ECommerceEntities1();
        }
        public User Add(User entity)
        {
            context.Users.Add(entity);
            int rowsEffected = context.SaveChanges();
            if (rowsEffected > 0)
            {
                return entity;
            }
            else
            {
                throw new Exception("User could not be added.");
            }
        }

        public bool Delete(int id)
        {
            User user= GetById(id);
            if (user != null)
            {
                user.Status = 4; //user account will be blocked
                int rowsEffected = context.SaveChanges();
                return rowsEffected > 0;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users =from user in context.Users.Include("Role")
                                    where user.Status == 1
                                    orderby user.Name
                                    select user;
            return users;
        }

        public User GetById(int id)
        {
            User user= (User)context.Users.Include("Role")
                        .Where((u) => u.Id == id && u.Status == 1)
                        .SingleOrDefault();
            return user;
        }

        public IEnumerable<User> GetByName(string name)
        {
            IEnumerable<User> users = from user in context.Users.Include("Role")
                                    where user.Status == 1 && user.Name.ToLower()== name.ToLower()
                                    orderby user.Name
                                    select user;
            return users;
        }

        public User Update(User entity)
        {
            User user= GetById(entity.Id);
            user.Name = entity.Name;
            user.DOB = entity.DOB;
            user.Email = entity.Email;
            user.Mobile = entity.Mobile;
            user.Gender = entity.Gender;
            user.RoleId = entity.RoleId;
            user.Status = entity.Status;
            int rowsEffected = context.SaveChanges();
            if (rowsEffected > 0)
            {
                return user;
            }
            else
            {
                throw new Exception("User could not be updated.");
            }
        }
    }
}