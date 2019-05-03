using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class UserContextMemory : IUserContext
    {
        private static List<UserDto> _users;
        private static bool _added;

        public UserContextMemory()
        {
            if (_added) return;
            _users = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Email = "rik@rik.nl",
                    Password = "Rik",
                    BirthDate = DateTime.Now,
                    FirstName = "Rik",
                    LastName = "Peeters",
                    Length = 179,
                    Blocked = false,
                    Right = new RightContextMemory().Read(1)
                },
                new UserDto
                {
                    Id = 2,
                    Email = "gert@gert.nl",
                    Password = "Gert",
                    BirthDate = DateTime.Now,
                    FirstName = "Gert",
                    LastName = "Peeters",
                    Length = 170,
                    Blocked = true,
                    Right = new RightContextMemory().Read(2)
                },
                new UserDto
                {
                    Id = 3,
                    Email = "jan@jan.nl",
                    Password = "Jan",
                    BirthDate = DateTime.Now,
                    FirstName = "Jan",
                    LastName = "Peeters",
                    Length = 170,
                    Blocked = false,
                    Right = new RightContextMemory().Read(3)
                },
                new UserDto
                {
                    Id = 4,
                    Email = "Sjaak@rik.nl",
                    Password = "Sjaak",
                    BirthDate = DateTime.Now,
                    FirstName = "Sjaak",
                    LastName = "Peeters",
                    Length = 170,
                    Blocked = false,
                    Right = new RightContextMemory().Read(3)
                }
            };
            _added = true;
        }

        private static UserDto Map(IUser user)
        {
            var password = _users.FirstOrDefault(u => u.Email == user.Email)?.Password;
            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Blocked = user.Blocked,
                Email = user.Email,
                Length = user.Length,
                Right = user.Right,          
            };
            if (password != null)
            {
                userDto.Password = password;
            }
            return userDto;
        }
        
        
        
        
        
        public bool Create(IUser user, string password)
        {
            if (_users.SingleOrDefault(u => u.Email == user.Email) != null) return false;
            var userDto = Map(user);
            userDto.Id = _users.Max(u => u.Id) + 1;
            userDto.Password = password;
                   
            _users.Add(userDto);
            return true;
        }
        
        
        
        
        
        public IUser Read(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }
        public IUser Read(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
        public IUser Read(IUser user)
        {
            return _users.SingleOrDefault(u => u.Id == user.Id);
        }


        
        
        
        public bool Update(IUser user)
        {
            try
            {
                _users[user.Id - 1] = Map(user);
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
                _users.Remove(_users.SingleOrDefault(u => u.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        
        
        
        
        
        public IEnumerable<IUser> List()
        {
            return _users;
        }

        
        
        
        
        public bool Auth(string email, string password)
        {
            var user = _users.SingleOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }
    }
}