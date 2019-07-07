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

		public async Task<JsonResult> GetFlight(string origin, string destination, DateTime depatureDate, DateTime arrivateDate, string currency = "")
		{
			List<Flights> dataFlights = new List<Flights>();
			Services.GetFlights flights = new Services.GetFlights(origin, destination, depatureDate, arrivateDate, currency);
			var source = await flights.GetData(origin, destination, depatureDate, arrivateDate, currency);
			var jsonObj = JsonConvert.DeserializeObject<RootObject>(source);

			var data = jsonObj.data;
			var dictionaries = jsonObj.dictionaries;
			var meta = jsonObj.meta;
			

			for (var i = 0; i < data.Count; i++)
			{
				foreach (var d in data[i].offerItems)
				{
					foreach (var s in d.services)
					{
						foreach (var n in s.segments)
						{
							dataFlights.Add(new Flights
							{
								Currency = meta.currency,
								Price = d.price.total,
								EndDateAndTime = n.flightSegment.Arrival.at.ToLongDateString(),
								StartDateAndTime = n.flightSegment.Departure.at.ToLongDateString(),
								End = n.flightSegment.Arrival.terminal,
								Start = n.flightSegment.Departure.terminal,
								NumberOfPassangers = n.flightSegment.Operating.number,
								StartAirport = n.flightSegment.Departure.iataCode,
								EndAirport = n.flightSegment.Arrival.iataCode
							});
						}
					}
				}
			}

			return Json(dataFlights, JsonRequestBehavior.AllowGet);
		}
	}
}