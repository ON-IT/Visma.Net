using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
   public class Application
    {     
        public string docType { get; set; }
      
        public string customerCD { get; set; }
       
        public string refNbr { get; set; }
      
        public decimal amountPaid { get; set; }
     
        public decimal cashDiscountTaken { get; set; }
      
        public decimal balance { get; set; }
       
        public bool pendingPPD { get; set; }
       
        public bool released { get; set; }
       
        public bool hold { get; set; }
      
        public bool voided { get; set; }
       
        public string ppdCrMemoRefNbr { get; set; }
     
        public string paymentRef { get; set; }

        public string status { get; set; }
  
        public DateTime applicationDate { get; set; }

        public string applicationPeriod { get; set; }

        public string invoiceText { get; set; }

    }


}
