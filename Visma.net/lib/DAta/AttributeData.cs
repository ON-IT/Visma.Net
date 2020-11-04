using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class AttributeData : BasePaginatedCrudDataClass<Models.Attribute>
    {
        public AttributeData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Attribute;
        }
    }
}