using System;
using System.Dynamic;

namespace ONIT.VismaNetApi.Models
{
    [Obsolete("Use IProvideIdentificator", true)]
    public interface IHaveNumber
    {
        [Obsolete("Use GetIdentificator()")]
        string number { get; }
    }
}