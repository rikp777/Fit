using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Data.dto;
using Interfaces;

namespace Data.Repositories
{
    public class UserRepository
    {
        private readonly IUserContext _context;
        private readonly StorageTypeSetting.StorageTypes _storageType;

        public UserRepository(StorageTypeSetting.StorageTypes storageType)
        {
            _storageType = storageType;
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new UserContextSQL();   
                    break;
                default: 
                    _context = new UserContextMemory(); 
                    break; 
            }
        }

        public IUser GetBy(int id)
        {
            IUser user = _context.Read(id);
            
            if (user == null) { return null; }
            
            user.Right = new RightRepository(_storageType).GetBy(user);
            return user;
        }

        public IUser GetBy(string email)
        {
            IUser user = _context.Read(email);
            
            if (user == null) { return null; }
            
            user.Right = new RightRepository(_storageType).GetBy(user);
            return user;
        }

        public IEnumerable<IUser> GetAll()
        {
            return _context.List();
        }

        public bool Add(IUser user)
        {
            return _context.Create(user);
        }

        public bool Edit(IUser user)
        {
            return _context.Update(user);
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }

        public UserDto GetAuth(string email)
        {
            return _context.Auth(email);
        }

    }
}