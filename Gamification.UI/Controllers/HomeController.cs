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

	public async Task<ActionResult> Index()
	{
		try
			{
				
				var userName = "eadeborna";
				var passwd = "Gamification123";
				var url = "https://e45z.4.ucc.md/sap/opu/odata/sap/ZUCC_GBM_SRV/MM_FSet(Id=2,User='LEARN-0034')?$format=json&sap-client=111";

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


				var thePoints = new Dictionary<string, int>()
				{
					{"@08@", 10},
					{"@09@", 8},
					{"@0A@", 7 },
					{"", 0}
				};

				List<int> sumPoint = new List<int>();

				foreach (var property in jToken.Children<JProperty>())
				{
					var dictionaryModel = new DictionaryModel
					{
						Key = property.Name,
						Value = property.Value.ToString()
					};
					switch (dictionaryModel.Key)
					{
						case "Step1":
							if (dictionaryModel.Key == "Step1")
							{
								var point = thePoints[dictionaryModel.Value];
								sumPoint.Add(point);
							}
							break;
						case "Step2":
							if (dictionaryModel.Key == "Step2")
							{
								var point = thePoints[dictionaryModel.Value];
								sumPoint.Add(point);
							}
							break;
						case "Step3":
							if (dictionaryModel.Key == "Step3")
							{
								var point = thePoints[dictionaryModel.Value];
								sumPoint.Add(point);
							}
							break;
						case "Step4":
							if (dictionaryModel.Key == "Step4")
							{
								var point = thePoints[dictionaryModel.Value];
								sumPoint.Add(point);
							}
							break;
					}
					dictionaryList.Add(dictionaryModel);
				}
				
				ViewBag.Point = sumPoint.Sum();

				//var dictList = new List<DictionaryModel>();

				//foreach (var prop in json.d.GetType().GetProperties())
				//{
				//	dictList.Add(new DictionaryModel { Key = prop.Name, Value = prop.GetValue(json.d)?.ToString() });
				//}




				// Parse JSON
				//JObject obj = JObject.Parse(json);

				// Loop through properties of the "d" object
				//foreach (JProperty prop in obj["d"])
				//{
				//	Console.WriteLine(prop.Name + ": " + prop.Value);
				//}

				//var step1 = json["d"]["Step1"];

				//Console.WriteLine(json);

				//SapViewModel sample = new SapViewModel()
				//{
				//	Data = new Models.Data()
				//	{
				//		Id = (int)json["d"]["Id"],
				//		User = (string)json["d"]["User"],
				//		Step1 = (string)json["d"]["Step1"],
				//		Step2 = (string)json["d"]["Step2"],
				//		Step3 = (string)json["d"]["Step3"],
				//		Step4 = (string)json["d"]["Step4"],
				//		Step5 = (string)json["d"]["Step5"],
				//		Step6 = (string)json["d"]["Step6"],
				//		Step7 = (string)json["d"]["Step7"],
				//		Step8 = (string)json["d"]["Step8"],
				//		Step9 = (string)json["d"]["Step9"],
				//		Step10 = (string)json["d"]["Step10"],
				//		Step11 = (string)json["d"]["Step11"],
				//		Step12 = (string)json["d"]["Step12"],
				//		Step13 = (string)json["d"]["Step13"],
				//		FulfillmentMandatory = (string)json["d"]["FulfillmentMandatory"],
				//		FulfillmentAll = (string)json["d"]["FulfillmentAll"]
				//	}
				//};

				//var thePoints = new Dictionary<string, int>()
				//{
				//	{"@08@", 10},
				//	{"@09@", 8},
				//	{"@0A@", 7 },
				//	{"", 12}
				//};

				//thePoints.Add("step1", "@08@");
				//var Point = thePoints[sample.Data.Step10] + thePoints[sample.Data.Step11];

				//SapViewModel data = new SapViewModel()
				//{
				//	Data = new Models.Data()
				//	{
				//		Id = sample.Data.Id,
				//		User = sample.Data.User,
				//		Step1 =   sample.Data.Step1.Substring(1,2),
				//		Step2 =   sample.Data.Step2.Substring(1,2),
				//		Step3 =   sample.Data.Step3.Substring(1,2),
				//		Step4 =   sample.Data.Step4.Substring(1,2),
				//		Step5 =   sample.Data.Step5.Substring(1,2),
				//		Step6 =   sample.Data.Step6.Substring(1,2),
				//		Step7 =   sample.Data.Step7.Substring(1,2),
				//		Step8 =   sample.Data.Step8.Substring(1,2),
				//		Step9 =   sample.Data.Step9.Substring(1, 2),
				//		Step10 =  sample.Data.Step10.Substring(1, 2),
				//		Step11 =  sample.Data.Step11.Substring(1, 2),
				//		Step12 =  sample.Data.Step12.Substring(1, 2),
				//		Step13 =  sample.Data.Step13.Substring(1, 2),
				//		FulfillmentMandatory = sample.Data.FulfillmentMandatory,
				//		FulfillmentAll = sample.Data.FulfillmentAll

				//	}
				//};
				//data.Data.Point = int.Parse(data.Data.Step1) + int.Parse(data.Data.Step2 );
				//data.Data.Badge = int.Parse(data.Data.Step3) + int.Parse(data.Data.Step4 );
				//Console.WriteLine(data.Data.FulfillmentMandatory);
				//return View(data);
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
