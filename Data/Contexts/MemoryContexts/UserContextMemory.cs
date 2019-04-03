using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Contexts.Interfaces;
using Data.dto;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class UserContextMemory : IUserContext
    {
        private static List<IUser> users;
        private static bool Added;

        public UserContextMemory()
        {
            if (!Added)
            {
                users = new List<IUser>();
                users.Add(new UserDto()
                {
                    Id = 1,
                    Email = "rik@rik.nl",
                    Password = "Rik",
                    BirthDate = DateTime.Now,
                    FirstName = "Rik",
                    LastName = "Peeters",
                    Length = 170,           
                    Blocked = false,
                });
                users.Add(new UserDto()
                {
                    Id = 2,
                    Email = "gert@gert.nl",
                    Password = "Gert",
                    BirthDate = DateTime.Now,
                    FirstName = "Gert",
                    LastName = "Peeters",
                    Length = 170, 
                    Blocked = true,
                });
                users.Add(new UserDto()
                {
                    Id = 3,
                    Email = "jan@jan.nl",
                    Password = "Jan",
                    BirthDate = DateTime.Now,
                    FirstName = "Jan",
                    LastName = "Peeters",
                    Length = 170,
                    Blocked = false,
                });
                users.Add(new UserDto()
                {
                    Id = 4,
                    Email = "Sjaak@rik.nl",
                    Password = "Sjaak",
                    BirthDate = DateTime.Now,
                    FirstName = "Sjaak",
                    LastName = "Peeters",
                    Length = 170,   
                    Blocked = false,
                });
                Added = true;
            }
        }
        public IUser Read(int id)
        {
            return users.SingleOrDefault(u => u.Id == id);
        }

        public IUser Read(string email)
        {
            return users.SingleOrDefault(u => u.Email == email);
        }

        public List<IUser> List()
        {
            return users;
        }

        public bool Create(IUser user)
        {
            if (user.Id == null)
            {
                user.Id = users.Max(u => u.Id) + 1;
            }

            if (users.SingleOrDefault(u => u.Email == user.Email) == null &&
                users.SingleOrDefault(u => u.Id == user.Id) == null)
            {
                users.Add(user);
                return true;
            }

            return false;
        }

        public bool Update(IUser user)
        {
            try
            {
                users[(int) (user.Id) - 1] = user;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                users.Remove(users.SingleOrDefault(u => u.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        
    }
}