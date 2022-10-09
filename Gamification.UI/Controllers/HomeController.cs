using Gamification.UI.Models;
using Gamification.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Gamification.UI.Controllers
{
    //[Authorize]
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
