using System.Collections.Generic;
using System.Data;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class WeightLogContextSQL : IWeightlogContext
    {
        private static List<WeightlogDto> _weightlogs;
        public WeightLogContextSQL()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            var dataTable = HelpFunctions.Query("WeightLog_GetAll");
            var weightlogsDto = dataTable.DataTableToList<WeightlogDto>();
            foreach (DataRow row in dataTable.Rows)
            {
                weightlogsDto.FirstOrDefault(w => w.Id == (int) row["Id"]).User = new UserContextSQL().Read((int) row["User_Id"]);
            }

            _weightlogs = weightlogsDto;
        }
        
        public bool Create(IWeightlog weightlog)
        {
            var parameters = new Dictionary<string, object>
            {
                {"User_Id", weightlog.User.Id},
                {"Weight", weightlog.Weight},
                {"DateTime", weightlog.DateTime}
            };

            var success = HelpFunctions.nonQuery("WeightLog_Insert", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        
        public IWeightlog Read(int id)
        {
            var weightLogDto = _weightlogs.FirstOrDefault(w => w.Id == id);

            return weightLogDto;
        }
        public IWeightlog Read(IWeightlog weightlog)
        {
            var weightLogDto = _weightlogs.FirstOrDefault(w => w.Id == weightlog.Id);

            return weightLogDto;
        }
        public IWeightlog ReadLast(IUser user)
        {
            var weightLogDto = _weightlogs.FirstOrDefault(w => w.User.Id == user.Id);

            return weightLogDto;
        }

        
        
        
        
        
        public bool Update(IWeightlog weightlog)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", weightlog.Id},
                {"User_Id", weightlog.User.Id},
                {"Weight", weightlog.Weight},
                {"DateTime", weightlog.DateTime}
            };

            var success = HelpFunctions.nonQuery("WeightLog_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id},
            };

            var success = HelpFunctions.nonQuery("WeightLog_Delete", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public IEnumerable<IWeightlog> List()
        {
            var weightLogsDto = _weightlogs;

            return weightLogsDto;
        }
        public IEnumerable<IWeightlog> List(IUser user)
        {
            var weightLogsDto = _weightlogs.Where(w => w.User.Id == user.Id);

            return weightLogsDto;
        }
    }
}