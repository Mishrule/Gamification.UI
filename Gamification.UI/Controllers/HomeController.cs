using Gamification.UI.Data;
using Gamification.UI.Models;
using Gamification.UI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Gamification.UI.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
	private readonly ILogger<HomeController> _logger;
	private readonly ITasksServices _tasksServices;

	public HomeController(ILogger<HomeController> logger, ITasksServices tasksServices)
	{
	  _tasksServices = tasksServices;
	  _logger = logger;
	}

	public IActionResult Index()
	{
	  return View();
	}
	[HttpPost]
	public async Task<IActionResult> Index(string username)
	{

	  var p = 0;
	  var b = 0;
	  var c = 0;

	  var points = 0;
	  var data = await _tasksServices.GetResponsePoint(username);
	  foreach (var item in data)
	  {
		points += item.Score;
	  }
	  if (points > 30)
	  {
		p = points;
		b = 2;
		c = 1;
	  }

	  else if (points >= 15 && points < 30)
	  {
		p = points;
		b = 1;
	  }
	  else
	  {
		p = points;
	  }

	  var dataa = new
	  {
		p,
		b,
		c
	  };

	  return Ok(dataa);
	}

	public async Task<IActionResult> LeaderBoard()
	{
		var data = await _tasksServices.GetLeaders();
	  return View(data);
	}

	public async Task<IActionResult> Tasks()
	{
	  var data = await _tasksServices.GetTasks();
	  return View(data);
	}
	[HttpPost]
	public async Task<IActionResult> TaskResponse(TasksResponse taskResponse)
	{
	  var data = await _tasksServices.CreateResponse(taskResponse);
	  //await Index(taskResponse.RespondantName);
	  return Ok(data);
	}

	public IActionResult TaskResponse()
	{

	  return View();
	}


	public IActionResult Privacy()
	{
	  return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
	  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
  }
}
