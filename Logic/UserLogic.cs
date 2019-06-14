using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.SQLContexts;
using Data.Dto;
using Data.Repositories;
using Enum;
using Logic.Models;
using Models;

namespace Logic
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;

        public UserLogic()
        {
            _userRepository = new UserRepository(StorageTypeSetting.Setting);
        }




        public IUser GetBy(int userId, int id)
        {
            if(CheckRight(userId, Right.Admin) || userId == id)
            {
                return _userRepository.GetBy(id);
            }

            return null;
        } 
        
        public IUser GetBy(string email)
        { 
            var userData = _userRepository.GetBy(email);
            
            if(!CheckRight(userData.Id, Right.Admin) || email == userData.Email)
            {
                return userData;
            }

            return null;
        } 
        
        
        
        
        public IEnumerable<IUser> GetAll(int userId)
        {
            return CheckRight(userId, Right.Admin) ? _userRepository.GetAll() : null;
        } 
        
        
        
        
        public bool Delete(int userId, int id)
        {
            if (!CheckRight(userId, Right.Admin) || userId == id) return false;
            
            return _userRepository.Delete(id);
        }

        public bool Register(IUser user, string password)
        {
            if(!validation(user)) return false;
            return _userRepository.Add(user, password); 
        }      
        
        
        
        
        /// <summary>
        /// 
        ///     Update
        ///
        ///     Right    = Admin
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Edit(int userId, IUser user)
        { 
            if (!CheckRight(userId, Right.Admin)) return false;
            if (!validation(user)) return false;
            
            return _userRepository.Edit(user);
        }

        
        
        
        public Message CheckLogin(string email, string password)
        {
            var success = _userRepository.CheckAuth(email, password);
            var message = new Message();
            if(success)
            {
                var authUser = _userRepository.GetBy(email);
                if (authUser.Blocked)
                {
                    message.Text = "User has been blocked";
                    message.Type = MessageType.Warning;
                }else
                {
                    message.Text = "Successfully login";
                    message.Type = MessageType.Success; 
                }           
            }
            else
            {
                message.Text = "Wrong credentials";
                message.Type = MessageType.Warning;   
            }                
                
            return message;
        }

        public bool ChangeUser(IUser user)
        {            
            return _userRepository.Edit(user);
        }

        //ToDo Change password 
        public bool ChangePassword(IUser user, string newPassword)
        {
            //user.Password = newPassword;
            return false; //Edit(user);
        }
        
        
        
        
        
        
        
        /// <summary>
        ///
        ///     return true when valid
        /// 
        ///     Exception      = 
        ///                    = Calories cant be more than 2000
        ///                    = Name cant be more than 50 
        ///
        /// </summary>
        private bool validation(IUser user)
        {
            if (user.Length > 300) return false;
            if (user.FirstName != null)
            {
                if (user.FirstName.Length > 50) return false;
            }


            return true;
        }

        
        
        
        /// returns true when valid 
        public static bool CheckRight(int UserId, Right hasRight)
        {                   
            return new UserRepository(StorageTypeSetting.Setting).GetBy(UserId).Right.Name == hasRight.ToString();
        }
    }
}