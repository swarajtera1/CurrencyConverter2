using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyServices.Interfaces
{
    public interface ICurrencyService
    {
        Task<decimal> CurrencyConvert(string from, string to, decimal amount);
    }
}
