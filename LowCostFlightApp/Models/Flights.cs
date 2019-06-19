using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LowCostFlightApp.Models
{
	public class Flights
	{
		public string Type { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
		public string RepartureDate { get; set; }
		public string ReturnDate { get; set; }
		public Price price { get; set; }
		public Links links { get; set; }
	}
	

	public class Price
	{
		public string Total { get; set; }
	}

	public class Links
	{
		public string FlightDates { get; set; }
		public string FlightOffers { get; set; }
	}


	public class RootObject
	{
		public List<Flights> Flights { get; set; }
	}
}