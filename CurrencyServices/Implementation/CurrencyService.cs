using CurrencyServices.Interfaces;
using DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyServices.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<decimal> CurrencyConvert(string from, string to, decimal amount)
        {
            string APiKey = "7594233de027295644513ee3";
            string url = "https://v6.exchangerate-api.com/v6/" + APiKey + "/pair/" + from + "/" + to;
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<API_obj>(response);
            var st = decimal.Parse(data.conversion_rate);
            var convertedAmount = amount * st;
            return convertedAmount;
        }
    }
}
