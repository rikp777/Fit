using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.SQLContexts;
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

        
        
        
        public IUser GetBy(int id) => _userRepository.GetBy(id);
        public IUser GetBy(string email) => _userRepository.GetBy(email);
        
        
        
        
        public IEnumerable<IUser> GetAll() => _userRepository.GetAll();
        
        
        
        
        public bool Delete(int id) => _userRepository.Delete(id);
        public bool Register(IUser user, string password) => _userRepository.Add(user, password);       
        
        
        
        
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
        private bool validation(IArticle article)
        {                          
//            if (!article.NutrientIntakes.Any()) return false;
//            foreach (var nutrientIntake in article.NutrientIntakes)
//            {
//                if (_nutrientRepository.GetBy(nutrientIntake.Nutrient) == null) return false;
//            }
            
            
            if (article.Calories > 2000) return false;
            if (article.Name != null)
            {
                if (article.Name.Length > 50) return false;
            }
            

            
            return true;
        }

        /// returns true when valid 
        private bool CheckRight(int id, Right right)
        {
            var UserData = _userRepository.GetBy(id);
           
            return UserData.Right.Name == right.ToString();
        }
    }
}