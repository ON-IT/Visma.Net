namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CurrencySummary : IdDescription
    {
        public string symbol { get; set; }
        public bool isBaseCurrency { get; set; }
        public int decimalPrecision { get; set; }
        public bool isUsedForAccounting { get; set; }
    }
}