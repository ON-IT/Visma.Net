using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CurrencyData : BaseCrudDataClass<Currency>
    {
        public CurrencyData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Currency;
        }

        protected CurrencyData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.Currency;
        }

        public override Task<Currency> Add(Currency entity)
        {
            throw new NotImplementedException("Not support by /currency");
        }

        public override Task Update(Currency entity)
        {
            throw new NotImplementedException("Not support by /currency");
        }
        public async Task<List<ExchangeRate>> GetExchangesRates(string toCurrencyId, DateTime effectiveDate)
        {
            return await VismaNetApiHelper.FetchExchangeRates(toCurrencyId, effectiveDate, Authorization);
        }

        public async Task<List<ExchangeRate>> AddExchangesRate(ExchangeRate exchangeRate)
        {
            return await VismaNetApiHelper.AddExchangeRate(exchangeRate, Authorization);
        }
        
        //Update Currency seams not to work in vismas api.
        public async Task<List<ExchangeRate>> UpdateExchangesRate(ExchangeRate exchangeRate)
        {
            return await VismaNetApiHelper.UpdateExchangeRate(exchangeRate, Authorization);
        }

    }
}
