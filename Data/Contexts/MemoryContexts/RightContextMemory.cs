using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.dto;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class RightContextMemory : IRightContext
    {
        private enum rightTypes
        {
            Admin, Instructor, Fitnesser
        }
        private static List<IRight> Rights;
        private static bool Added;

        public RightContextMemory()
        {
            if (!Added)
            {
                Rights = new List<IRight>();
                Rights.Add(new RightDto
                {
                    Id = 1,
                    Name = rightTypes.Admin.ToString(),
                    Description = rightTypes.Admin.ToString()
                });
                Rights.Add(new RightDto
                {
                    Id = 1,
                    Name = rightTypes.Instructor.ToString(),
                    Description = rightTypes.Instructor.ToString()
                });
                Rights.Add(new RightDto
                {
                    Id = 1,
                    Name = rightTypes.Fitnesser.ToString(),
                    Description = rightTypes.Fitnesser.ToString()
                });
                Added = true;
            }
        }
        public IRight Read(int id)
        {
            return Rights.SingleOrDefault(r => r.Id == id);
        }

        public IRight Read(string name)
        {
            return Rights.SingleOrDefault(r => r.Name == name);
        }

        public IRight Read(IUser user)
        {
            return Rights.SingleOrDefault(r => r.Name == rightTypes.Admin.ToString());
        }

        public List<IRight> List()
        {
            return Rights;
        }
    }
}