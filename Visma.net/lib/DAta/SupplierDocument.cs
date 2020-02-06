using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierDocumentData : BaseCrudDataClass<SupplierDocument>
    {
        public SupplierDocumentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SupplierDocument;
        }

    }
}