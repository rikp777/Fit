using System.Collections.Generic;
using System.Data;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class GoalLogsContextSql : IGoalLogContext
    {
        private static List<GoalLogDto> _goalLogs;
        public GoalLogsContextSql()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            var dataTable = HelpFunctions.Query("GoalLog_GetAll");
            var goalLogsDto = dataTable.DataTableToList<GoalLogDto>();
            foreach (DataRow row in dataTable.Rows)
            {
                goalLogsDto.FirstOrDefault(w => w.Id == (int) row["Id"]).User = new UserContextSQL().Read((int) row["User_Id"]);
            }

            _goalLogs = goalLogsDto;
        }

        
        
        
        
        public bool Create(IGoalLog goalLog)
        {
            var parameters = new Dictionary<string, object>
            {
                {"User_Id", goalLog.User.Id},
                {"Calories", goalLog.Calories},
                {"DateTime", goalLog.DateTime}
            };

            var success = HelpFunctions.nonQuery("GoalLog_Insert", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public IGoalLog Read(int id)
        {
            var goalLogDto = _goalLogs.FirstOrDefault(g => g.Id == id);

            return goalLogDto;
        }
        public IGoalLog Read(IGoalLog goalLog)
        {
            var goalLogDto = Read(goalLog.Id);

            return goalLogDto;
        }
        public IGoalLog ReadLast(IUser user)
        {
            var goalLogDto = _goalLogs.FirstOrDefault(g => g.User.Id == user.Id);

            return goalLogDto;
        }

        
        
        
        
        
        public bool Update(IGoalLog goalLog)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", goalLog.Id},
                {"User_Id", goalLog.User.Id},
                {"Calories", goalLog.Calories},
                {"DateTime", goalLog.DateTime}
            };

            var success = HelpFunctions.nonQuery("GoalLog_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id}
            };

            var success = HelpFunctions.nonQuery("WeightLog_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public IEnumerable<IGoalLog> List()
        {
            var goalsDto = _goalLogs;
            
            return goalsDto;
        }
        public IEnumerable<IGoalLog> List(IUser user)
        {
            var goalsDto = _goalLogs.Where(g => g.User.Id == user.Id);
            
            return goalsDto;
        }
    }
}