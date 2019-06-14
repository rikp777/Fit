using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class RightContextSQL : IRightContext
    {
        private static List<RightDto> _rights;

        public RightContextSQL()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            _rights = HelpFunctions.Query("Right_GetAll").DataTableToList<RightDto>();
        }
        
        
        
        
        
        public IRight Read(int id)
        {
            var rightDto = _rights.FirstOrDefault(r => r.Id == id);

            return rightDto;
        }
        public IRight Read(string name)
        {
             var rightDto = _rights.FirstOrDefault(r => r.Name == name);
            
            return rightDto;
        }
        public IRight Read(IUser user)
        {
            var rightDto = Read(user.Id);

            return rightDto;
        }

        public IEnumerable<IRight> List()
        {
            var rightDto = _rights;

            return rightDto;
        }
    }
}