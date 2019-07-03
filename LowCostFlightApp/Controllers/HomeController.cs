using DevExtreme.AspNet.Mvc;
using LowCostFlightApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LowCostFlightApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> GetFlight()
		{
			Services.GetFlights flights = new Services.GetFlights();
			var source = await flights.GetData("MAD", "JFK", DateTime.Now.AddDays(10), null, null, null);
			var jsonObj = JsonConvert.DeserializeObject<RootObject>(source);

			var data = jsonObj.data;
			var dictionaries = jsonObj.dictionaries;
			var meta = jsonObj.meta;

			return Json(data, JsonRequestBehavior.AllowGet);
		}
	}
}