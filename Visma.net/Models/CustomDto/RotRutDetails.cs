using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    class RotRutDetails : DtoProviderBase
    {
        public bool distributedAutomaticaly
        {
            get => Get<bool>();
            set => Set(value);
        }
        public string type
        {
            get => Get<string>();
            set => Set(value);
        }

        public string appartment
        {
            get => Get<string>();
            set => Set(value);
        }
        public string estate
        {
            get => Get<string>();
            set => Set(value);
        }
        public string organizationNbr
        {
            get => Get<string>();
            set => Set(value);
        }
        [JsonProperty]
        public List<RotRutDistribution> distribution
        {
            get => Get(defaultValue: new List<RotRutDistribution>());
            private set => Set(value);
        }

    }
}
