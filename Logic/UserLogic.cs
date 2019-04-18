using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
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
        private readonly UserRepository _repository;

        public UserLogic()
        {
            _repository = new UserRepository(StorageTypeSetting.Setting);
        }

        
        
        
        public IUser GetBy(int id) => _repository.GetBy(id);
        public IUser GetBy(string email) => _repository.GetBy(email);
        
        
        
        
        public IEnumerable<IUser> GetAll() => _repository.GetAll();
        
        
        
        
        public bool Delete(int id) => _repository.Delete(id);
        public bool Register(IUser user, string password) => _repository.Add(user, password);       
        private bool Edit(IUser user) => _repository.Edit(user);

        
        
        
        public Message CheckLogin(string email, string password)
        {
            var success = _repository.CheckAuth(email, password);
            var message = new Message();
            if(success)
            {
                var authUser = _repository.GetBy(email);
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
            return user.Id != null && Edit(user);
        }

        //ToDo Change password 
        public bool ChangePassword(IUser user, string newPassword)
        {
            //user.Password = newPassword;
            return Edit(user);
        }
    }
}