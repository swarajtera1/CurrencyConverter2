using CurrencyServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyConverterController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("ConvertAmount/", Name = "ConvertAmountCurrencies")]
        public async Task<IActionResult> ConvertAmountCurrencies(string Fromcurrency, string Tocurrency, decimal amount)
        {
            ResponseObject resObject;

            decimal convertedamount = await _currencyService.CurrencyConvert(Fromcurrency, Tocurrency, amount);
            resObject = new ResponseObject
            {
                Message = "Converted Amount",
                Status = "success",
                Data = convertedamount,
                HttpStatusCode = HttpStatusCode.OK
            };
            return Json(resObject);
        }

    }
}
