using System;
using System.Collections.Generic;
using Gamification.UI.Data;
using Gamification.UI.Models;
using Gamification.UI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using static Gamification.UI.Models.SapModel;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Gamification.UI.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
	private readonly ILogger<HomeController> _logger;
	private readonly ITasksServices _tasksServices;
	private readonly HttpClient _client;
	private readonly IConfiguration _configuration;
	public string Base { get; set; }

	public HomeController(ILogger<HomeController> logger, ITasksServices tasksServices, HttpClient client,
		IConfiguration configuration)
	{
		_tasksServices = tasksServices;
		_client = client;
		_configuration = configuration;
		//Base = _configuration.GetValue<string>("APIKey");
		_logger = logger;
	}

	public String GetUrl(int clientId, String userId, String applicationServer)
	{
	  return	$"https://{applicationServer}/sap/opu/odata/sap/ZUCC_GBM_SRV/MM_FSet(Id=2,User='{userId}')?$format=json&sap-client={clientId}";
	}


	public async Task<ActionResult> Index(int clientId, String userId, String applicationServer)
	{
		try
			{
				
				var userName = "eadeborna";
				var passwd = "Gamification123";
				var url = GetUrl(clientId, userId, applicationServer);

				// use this handler to allow untrusted SSL Certificates
				var handler = new HttpClientHandler();
				handler.ClientCertificateOptions = ClientCertificateOption.Manual;
				handler.ServerCertificateCustomValidationCallback =
					(httpRequestMessage, cert, cetChain, policyErrors) =>
					{
						return true;
					};

				using var client = new HttpClient(handler);

				var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
					Convert.ToBase64String(authToken));

				var result = await client.GetAsync(url);

				var content = await result.Content.ReadAsStringAsync();

				//dynamic data = JsonConvert.DeserializeObject<dynamic>(content);

				// Access the properties like this:
				//int id = data.d.Id;
				//string user = data.d.User;
				//string step1 = data.d.Step1;
				//string step2 = data.d.Step2;
				//string step3 = data.d.Step3;
				//string step4 = data.d.Step4;
				//string step5 = data.d.Step5;
				//string step6 = data.d.Step6;
				//string step7 = data.d.Step7;
				//string step8 = data.d.Step8;
				//string step9 = data.d.Step9;
				//string step10 = data.d.Step10;
				//string step11 = data.d.Step11;
				//string step12 = data.d.Step12;
				//string step13 = data.d.Step13;
				//string fulfillmentMandatory = data.d.FulfillmentMandatory;
				//string fulfillmentAll = data.d.FulfillmentAll;



				//dynamic json = JsonConvert.DeserializeObject(content);
				//ParseJson(json);
				var dictionaryList = new List<DictionaryModel>();
				var jObject = JObject.Parse(content);
				var jToken = jObject["d"];


				var PiontsDictionary = new Dictionary<string, int>()
				{
					{"@08@", 10},
					{"@09@", 8},
					{"@0A@", 7 },
					{"", 0}
				};

				foreach (var property in jToken.Children<JProperty>())
				{
					var dictionaryModel = new DictionaryModel
					{
						Key = property.Name,
						Value = property.Value.ToString()
					};
					dictionaryList.Add(dictionaryModel);
				}

				// Get points for that specific learn id
				int point = 0;
				int level = 0;
				List<int> Points = new List<int>();
				foreach (var item in dictionaryList)
				{
					if (item.Key.Contains("Step"))
					{
						point = PiontsDictionary[item.Value];
						Points.Add(point);
						if (point != 0)
							level++;
					}
				}

				ViewBag.Point = Points.Sum();
				ViewBag.Levels = level;


				
				return View();
			}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		

			
	}
	public static List<DictionaryModel> ParseJson(string jsonString)
	{
		var dictionaryList = new List<DictionaryModel>();
		var jObject = JObject.Parse(jsonString);
		var jToken = jObject["d"];

		foreach (var property in jToken.Children<JProperty>())
		{
			var dictionaryModel = new DictionaryModel
			{
				Key = property.Name,
				Value = property.Value.ToString()
			};
			dictionaryList.Add(dictionaryModel);
		}

		return dictionaryList;
	}
		public class DictionaryModel
	{
		public string Key { get; set; }
		public string Value { get; set; }
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

	public IActionResult Badges()
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
