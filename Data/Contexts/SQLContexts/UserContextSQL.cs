using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Data.Contexts.Interfaces;
using Data.Dto;
using Data.Repositories;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class UserContextSQL : IUserContext
    {
        private static List<UserDto> _users;

        public UserContextSQL()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            _users = HelpFunctions.Query("User_GetAll").DataTableToList<UserDto>();
            foreach (var user in _users)
            {
                var parameters = new Dictionary<string, object>
                {
                    {"User_Id", user.Id}
                };
                user.Right = HelpFunctions.Query("Right_GetByUser", parameters).DatatableToObject<RightDto>();
            }
        }
        
        
        
        
        
        public bool Create(IUser user, string password)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Firstname", user.FirstName}, 
                {"Lastname", user.LastName},
                {"Email", user.Email},
                {"Password", password},
                {"Length", user.Length},
                {"Birth_Date", user.BirthDate},
                {"Blocked", user.Blocked},
                {"Right_Id", user.Right.Id},
            };

            var success = HelpFunctions.nonQuery("User_Insert", parameters);

            InstantiateContextSQL();
            
            return success;
        }
        
        
        
        
        
        public IUser Read(int id)
        {
            var userDto = _users.FirstOrDefault(u => u.Id == id);
            
            return userDto;
        }
        public IUser Read(string email)
        {
            var userDto = _users.FirstOrDefault(u => u.Email == email);
            
            return userDto;
        }
        public IUser Read(IUser user)
        {
            var userDto = Read(user.Id);

            return userDto;
        }





        public bool Update(IUser user)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", user.Id},
                {"Firstname", user.FirstName}, 
                {"Lastname", user.LastName},
                {"Email", user.Email},
                {"Length", user.Length},
                {"Birth_Date", user.BirthDate},
                {"Blocked", user.Blocked},
                {"Right_Id", user.Right.Id},
            };

            var success = HelpFunctions.nonQuery("User_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }
        
        
        
        
        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id}
            };

            var success = HelpFunctions.nonQuery("User_Delete", parameters);

            InstantiateContextSQL();
            
            return success;
        }
        
        
        
        
        
        public IEnumerable<IUser> List()
        {
            var usersDto = _users;
            return usersDto;
        }

             
        
        
        
        public bool Auth(string email, string password)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Email", email},
                {"password", password}
            };
            
            var UserDto = HelpFunctions.Query("User_Auth", parameters).DatatableToObject<UserDto>();
            
            return UserDto != null;
        }


        
        
        


//        private static IEnumerable<IUser> BuildUserDtoList(DataTable dataTable)
//        {
//            var usersDto = new List<UserDto>();
//            foreach (DataRow row in dataTable.Rows)
//            {
//                var userDto = new UserDto
//                {
//                    Id = (int) dataTable.Rows[0]["Id"],
//                    FirstName = (string) dataTable.Rows[0]["Firstname"],
//                    LastName = (string) dataTable.Rows[0]["Lastname"],
//                    Email = (string) dataTable.Rows[0]["Email"],
//                    Length = (int) dataTable.Rows[0]["Lenght"],
//                    BirthDate = (DateTime) dataTable.Rows[0]["BirthDate"],
//                    Blocked = (bool) dataTable.Rows[0]["Blocked"],
//                    Right = new RightDto
//                    {
//                        Id = (int) dataTable.Rows[0]["Right_Id"],
//                        Name = (string) dataTable.Rows[0]["Name"],
//                        Description = (string) dataTable.Rows[0]["Description"]
//                    }
//                };
//                usersDto.Add(userDto);
//            }
//
//            return usersDto;
//        }
//        private static UserDto BuildUserDto(DataTable dataTable)
//        {
//            var userDto = new UserDto
//            {
//                Id = (int) dataTable.Rows[0]["Id"],
//                FirstName = (string) dataTable.Rows[0]["Firstname"],
//                LastName = (string) dataTable.Rows[0]["Lastname"],
//                Email = (string) dataTable.Rows[0]["Email"],
//                Length = (int) dataTable.Rows[0]["Lenght"],
//                BirthDate = (DateTime) dataTable.Rows[0]["BirthDate"],
//                Blocked = (bool) dataTable.Rows[0]["Blocked"],
//                Right = new RightDto
//                {
//                    Id = (int) dataTable.Rows[0]["Right_Id"],
//                    Name = (string) dataTable.Rows[0]["Name"],
//                    Description = (string) dataTable.Rows[0]["Description"]
//                }
//            };
//
//            return userDto;
//        }
    }
}