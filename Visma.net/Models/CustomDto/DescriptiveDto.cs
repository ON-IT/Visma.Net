using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Annotations;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{

    public class DescriptiveDto : IBecomeDto, INotifyPropertyChanged
    {
        private string _id;

        public DescriptiveDto(string id)
        {
            this.id = id;
        }

        public DescriptiveDto()
        {
        }

        [JsonProperty]
        public string description { get; private set; }

        public string id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public DtoValue ToDto()
        {
            if (!string.IsNullOrEmpty(id))
                return new DtoValue(id);
            return null;
        }

        public static implicit operator DescriptiveDto(string id)
        {
            return new DescriptiveDto
            {
                id = id
            };
        }

        public static T FromId<T>(string id) where T : DescriptiveDto, new()
        {
            return new T
            {
                id = id
            };
        }

        public override string ToString()
        {
            return id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DescriptionId : DescriptiveDto
    {
        public static implicit operator DescriptionId(string id)
        {
            return new DescriptionId
            {
                id = id
            };
        }
    }
    public class CreditTerms : DescriptiveDto
    {
        public CreditTerms()
        {
        }

        public CreditTerms(string id) : base(id)
        {
        }

        public static implicit operator CreditTerms(string id)
        {
            return new CreditTerms(id);
        }
    }

    public class VatCode : DescriptiveDto
    {
        public VatCode()
        {
        }

        public static implicit operator VatCode(string id)
        {
            return new VatCode
            {
                id = id
            };
        }
        
        public VatCode(string id)
            : base(id)
        {
        }
    }

    public class Vat : DescriptiveDto
    {
        public Vat()
        {
        }

        public Vat(string id)
            : base(id)
        {
        }

        public static implicit operator Vat(string id)
        {
            return new Vat()
            {
                id = id
            };
        }
    }

    public class VatZone : DescriptiveDto
    {
        public VatZone()
        {
        }

        public VatZone(string id)
            : base(id)
        {

        }

        
        [JsonProperty]
        public string defaultVatCategory { get; private set; }

        public static implicit operator VatZone(string id)
        {
            return new VatZone()
            {
                id = id
            };
        }
    }

    public class CustomerClass : DescriptiveDto
    {
       // public string id { get; set; }
        public string description { get; set; }
        public string taxZoneId { get; set; }
        public bool requiredTaxzoneId { get; set; }
        public string paymentMethodId { get; set; }
        public List<AttributeDefinition> attributes { get; set; }

        public CustomerClass()
        {

        }

        public CustomerClass(string id) : base(id)
        {
        }

        public static implicit operator CustomerClass(string id)
        {
            return new CustomerClass
            {
                id = id
            };
        }
    }

    public class SupplierClass : DescriptiveDto
    {
        public SupplierClass()
        {
        }

        public SupplierClass(string id) : base(id)
        {
        }

        public static implicit operator SupplierClass(string id)
        {
            return new SupplierClass
            {
                id = id
            };
        }
    }

    public class ItemClass : DescriptiveDto
    {
        public string type { get; set; }
        public List<AttributeDefinition> attributes { get; set; }
        public ItemClass()
        {
        }

        public ItemClass(string id) : base(id)
        {
        }

        public static implicit operator ItemClass(string id)
        {
            return new ItemClass(id);
        }
    }

    public class AttributeDefinition
    {
        public string attributeid { get; set; }
        public string description { get; set; }
        public int sortorder { get; set; }
        public bool required { get; set; }
        public string attributetype { get; set; }
        public string defaultvalue { get; set; }
        public List<AttributeDefinitionDetail> details { get; set; }
    }

    public class AttributeDefinitionDetail
    {
        public string id { get; set; }
        public string description { get; set; }
    }
    

    public class PostingClass : DescriptiveDto
    {
        public PostingClass()
        {
        }

        public PostingClass(string id) : base(id)
        {
        }

        public static implicit operator PostingClass(string id)
        {
            return new PostingClass(id);
        }
    }
}