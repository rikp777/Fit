using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.SQLContexts;
using Data.dto;
using Data.Repositories;
using Interfaces;
using Logic.Models;

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
        public bool IsAdmin(int id)
        {
            var right = new RightLogic().GetBy(3);
            var user = _repository.GetBy(id);
            if (user.Right.Id == right.Id)
            {
                return true;
            }
            return false;
        }

        public Message CheckLogin(string email, string password)
        {
            var user = _repository.GetAuth(email);
            Message message = new Message();
            if (user != null)
            {
                if (user.Email == email && user.Password == password)
                {
                    if (!user.Blocked)
                    {
                        message.Text = "Successfully login";
                        message.Type = MessageType.Success;
                    }
                    else
                    {
                        message.Text = "User has been blocked";
                        message.Type = MessageType.Warning;
                    }
                }
                else
                {
                    message.Text = "Wrong credentials";
                    message.Type = MessageType.Warning;
                }
            }
            else
            {
                message.Text = "User Unknown";
                message.Type = MessageType.Warning;
            }
                
            return message;
        }

        public bool ChangeUser(IUser user)
        {
            if(user.Id != null)
            {
                return Edit(user);
            }
            return false;
        }

        public bool ChangePassword(IUser user, string newPassword)
        {
            //user.Password = newPassword;
            return Edit(user);
        }
    }
}