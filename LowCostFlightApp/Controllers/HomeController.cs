using DevExtreme.AspNet.Mvc;
using LowCostFlightApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
			var source = await flights.GetData();

			List<Flights> listreg = new List<Flights>();

			var data = JObject.Parse(source);
			return Json(data, JsonRequestBehavior.AllowGet);
		}
	}
}