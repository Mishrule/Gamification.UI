using Gamification.UI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gamification.UI.Services.Interfaces
{
  public interface ITasksServices
  {
	Task<IEnumerable<Tasks>> GetTasks();
	Task<IEnumerable<TasksResponse>> GetResponsePoint(string username);
	Task<bool> CreateResponse(TasksResponse tasksResponse);
	//Task<int> GetLeaders();
  }
}
