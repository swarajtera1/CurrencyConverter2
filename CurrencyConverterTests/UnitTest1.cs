using NUnit.Framework;
using CurrencyConverter;
using CurrencyConverter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using CurrencyServices.Implementation;

namespace CurrencyConverterTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var mockRepo = new Mock<CurrencyService>();
            CurrencyConverterController home = new CurrencyConverterController(mockRepo.Object);
            JsonResult result = (JsonResult)await home.ConvertAmountCurrencies("USD", "PKR", 10);


            var json = JsonConvert.SerializeObject(result.Value);

            var deserializeData = JsonConvert.DeserializeObject<ResponseObject>(json);

            Assert.AreEqual(1690.711, deserializeData.Data);


        }
    }
}