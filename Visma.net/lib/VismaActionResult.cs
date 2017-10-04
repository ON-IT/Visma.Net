using System;

namespace ONIT.VismaNetApi.Lib
{
    public class VismaActionResult
    {
        public Guid ActionId { get; set; }
        public object ActionResult { get; set; }
        public string ErrorInfo { get; set; }
    }
}