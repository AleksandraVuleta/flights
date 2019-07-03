using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LowCostFlightApp.Models
{
	public class Departure
	{
		public string iataCode { get; set; }
		public string terminal { get; set; }
		public DateTime at { get; set; }
	}

	public class Arrival
	{
		public string iataCode { get; set; }
		public string terminal { get; set; }
		public DateTime at { get; set; }
	}

	public class Aircraft
	{
		public string code { get; set; }
	}

	public class Operating
	{
		public string carrierCode { get; set; }
		public string number { get; set; }
	}

	public class FlightSegment
	{
		public Departure departure { get; set; }
		public Arrival arrival { get; set; }
		public string carrierCode { get; set; }
		public string number { get; set; }
		public Aircraft aircraft { get; set; }
		public Operating operating { get; set; }
		public string duration { get; set; }
	}

	public class PricingDetailPerAdult
	{
		public string travelClass { get; set; }
		public string fareClass { get; set; }
		public int availability { get; set; }
		public string fareBasis { get; set; }
	}

	public class Segment
	{
		public FlightSegment flightSegment { get; set; }
		public PricingDetailPerAdult pricingDetailPerAdult { get; set; }
	}

	public class Service
	{
		public List<Segment> segments { get; set; }
	}

	public class Price
	{
		public string total { get; set; }
		public string totalTaxes { get; set; }
	}

	public class PricePerAdult
	{
		public string total { get; set; }
		public string totalTaxes { get; set; }
	}

	public class OfferItem
	{
		public List<Service> services { get; set; }
		public Price price { get; set; }
		public PricePerAdult pricePerAdult { get; set; }
	}

	public class Datum
	{
		public string type { get; set; }
		public string id { get; set; }
		public List<OfferItem> offerItems { get; set; }
	}

	public class Carriers
	{
		public string DY { get; set; }
		public string TP { get; set; }
	}

	public class Currencies
	{
		public string EUR { get; set; }
	}

	public class Aircraft2
	{
		public string __invalid_name__789 { get; set; }
		public string __invalid_name__339 { get; set; }
		public string __invalid_name__319 { get; set; }
	}

	public class MAD
	{
		public string subType { get; set; }
		public string detailedName { get; set; }
	}

	public class LIS
	{
		public string subType { get; set; }
		public string detailedName { get; set; }
	}

	public class JFK
	{
		public string subType { get; set; }
		public string detailedName { get; set; }
	}

	public class Locations
	{
		public MAD MAD { get; set; }
		public LIS LIS { get; set; }
		public JFK JFK { get; set; }
	}

	public class Dictionaries
	{
		public Carriers carriers { get; set; }
		public Currencies currencies { get; set; }
		public Aircraft2 aircraft { get; set; }
		public Locations locations { get; set; }
	}

	public class Links
	{
		public string self { get; set; }
	}

	public class Defaults
	{
		public bool nonStop { get; set; }
		public int adults { get; set; }
	}

	public class Meta
	{
		public Links links { get; set; }
		public string currency { get; set; }
		public Defaults defaults { get; set; }
	}

	public class RootObject
	{
		public List<Datum> data { get; set; }
		public Dictionaries dictionaries { get; set; }
		public Meta meta { get; set; }
	}
}