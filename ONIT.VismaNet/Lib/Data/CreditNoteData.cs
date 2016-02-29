using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
	public class CreditNoteData : BaseCrudDataClass<CreditNote>
	{
        /// <summary>
		///     This constructor is called by the client to create the data source.
		/// </summary>
		internal CreditNoteData(VismaNetAuthorization auth) : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.CreditNote;
		}

	    protected CreditNoteData() : base(null)
	    {
            ApiControllerUri = VismaNetControllers.CreditNote;
	        
	    }
    }
}

