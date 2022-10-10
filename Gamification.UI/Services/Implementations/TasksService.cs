using Gamification.UI.Data;
using Gamification.UI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

	public async Task<IEnumerable<TasksResponse>> GetResponsePoint(string username)
	{
	  var data = await _db.Responses.Where(q => q.RespondantName == username).ToListAsync();
	  return data;
	}

	public async Task<bool> CreateResponse(TasksResponse tasksResponse)
	{
	  await _db.Responses.AddAsync(tasksResponse);
	  var save = await _db.SaveChangesAsync();
	  return save > 0;
	}

	//public async Task<int> GetLeaders()
	//{
	// var data =  _db.Responses.Where(s=>s.RespondantName==username).Sum(q=>q.Score);
	//var data =  _db.Responses.GroupBy(c => c.RespondantName).
	//	  Select(g => new
	//	  {
	//		g.Key,
	//		SUM = g.Sum(s => s.Score)//.Inqueries.Select(t => t.TotalTimeSpent).Sum())
	//	  });
	//var data = _db.Responses.FindAsync().GroupBy(i => i.RespondantName).Sum(c => c.Sum(a => a.Score));


	//var query = from p in _db.Responses
	//	  group p by p.RespondantName
	//into g
	//	  where g.Sum(a=>a.Score)
	//	  orderby g.Key
	//	  select new { g.Key, Sum = g.Sum() };

	//return data;
	//}
  }
}
