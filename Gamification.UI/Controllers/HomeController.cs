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
            var points = 0;
            var data = await _tasksServices.GetResponsePoint(username);
            foreach (var item in data)
            {
                points += item.Score;
            }
            return Ok(points);
        }

        public IActionResult LeaderBoard()
        {
            return View();
        }

        public async Task<IActionResult> Tasks()
        {
            var data = await _tasksServices.GetTasks();
            return View(data);
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
