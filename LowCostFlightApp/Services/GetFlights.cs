using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LowCostFlightApp.Services
{
	public class GetFlights
	{
		dynamic access_token;

		public GetFlights()
		{
			 GetData("MAD", "JFK", DateTime.Now.AddDays(10), null, null, null).ConfigureAwait(false);
		}

		public async Task<string> GetData(string origin, string destination, DateTime depatureDate, DateTime? arrivateDate, int? numberOfPassangers, string currency = "")
		{
			GenerateAccesToken();

			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("https://test.api.amadeus.com/");
			httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);

			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(httpClient.BaseAddress + $"v1/shopping/flight-offers?origin=" + origin + "&destination=" + destination + "&departureDate=2019-08-01&max=2"),
				Method = HttpMethod.Get
			};

			var result = await httpClient.GetAsync(request.RequestUri);
			if (result.IsSuccessStatusCode)
			{
				var response = await httpClient.SendAsync(request).ConfigureAwait(false);
				var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

				return reader.ReadToEnd();
			}
			else
				return "";
		}


		public void GenerateAccesToken()
		{
			var values = new Dictionary<string, string>
			{
			   { "client_id", "Umn8BDExUCm9eQd9Ncq2s9vQgUFcVXGo" },
			   { "client_secret", "7wMPbQipxrDJoaJJ" },
			   { "grant_type", "client_credentials" }
			};


			HttpClient client = new HttpClient();

			var content = new FormUrlEncodedContent(values);
			var response = client.PostAsync("https://test.api.amadeus.com/v1/security/oauth2/token", content);
			string json = response.Result.Content.ReadAsStringAsync().Result;
			dynamic obj = JObject.Parse(json);
			access_token = obj.access_token;
		}

	}
}