using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class RightContextMemory : IRightContext
    {
        private enum RightTypes
        {
            Admin = 0, Instructor = 1, Fitnesser = 2
        }
        private static List<IRight> _rights;
        private static bool _added;

        public RightContextMemory()
        {
            if (_added) return;
            _rights = new List<IRight>
            {
                new RightDto
                {
                    Id = 1, Name = RightTypes.Admin.ToString(), Description = RightTypes.Admin.ToString()
                },
                new RightDto
                {
                    Id = 2,
                    Name = RightTypes.Instructor.ToString(),
                    Description = RightTypes.Instructor.ToString()
                },
                new RightDto
                {
                    Id = 3,
                    Name = RightTypes.Fitnesser.ToString(),
                    Description = RightTypes.Fitnesser.ToString()
                }
            };
            _added = true;
        }
        
        
        
        
        
        public IRight Read(int id)
        {
            return _rights.SingleOrDefault(r => r.Id == id);
        }
        public IRight Read(string name)
        {
            return _rights.SingleOrDefault(r => r.Name == name);
        }
        public IRight Read(IUser user)
        {
            return _rights.SingleOrDefault(r => r.Name == RightTypes.Admin.ToString());
        }

        
        
        
        
        public IEnumerable<IRight> List()
        {
            return _rights;
        }
    }
}