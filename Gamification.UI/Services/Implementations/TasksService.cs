using Gamification.UI.Data;
using Gamification.UI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gamification.UI.Services.Implementations
{
    public class TasksService : ITasksServices
    {
        public readonly ApplicationDbContext _db;
        public TasksService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            var data = await _db.Tasks.ToListAsync();
            return data;
        }


    }
}
