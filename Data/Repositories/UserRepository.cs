using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Models;

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
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new UserContextMemory(); 
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }

        
        
        
        
        public IUser GetBy(int id) => _context.Read(id);
        public IUser GetBy(string email) => _context.Read(email);





        public IEnumerable<IUser> GetAll() => _context.List();





        public bool Add(IUser user, string password) => _context.Create(user, password);
        public bool Edit(IUser user) => _context.Update(user);
        public bool Delete(int id) => _context.Delete(id);





        public bool CheckAuth(string email, string password) => _context.Auth(email, password);
    }
}