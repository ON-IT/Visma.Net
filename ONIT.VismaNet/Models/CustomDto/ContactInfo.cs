using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ONIT.VismaNetApi.Annotations;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class ContactInfo : IProvideDto, INotifyPropertyChanged
    {
        private string _fax;
        private string _phone2;
        private string _phone1;
        private string _web;
        private string _email;
        private string _attention;
        private string _name;
        private int _contactId;

        public int contactId
        {
            get { return _contactId; }
            set
            {
                if (value == _contactId) return;
                _contactId = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(contactIdSpecified));
            }
        }

        public string name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string attention
        {
            get { return _attention; }
            set
            {
                if (value == _attention) return;
                _attention = value;
                OnPropertyChanged();
            }
        }

        public string email
        {
            get { return _email; }
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        public string web
        {
            get { return _web; }
            set
            {
                if (Equals(value, _web)) return;
                _web = value;
                OnPropertyChanged();
            }
        }

        public string phone1
        {
            get { return _phone1; }
            set
            {
                if (value == _phone1) return;
                _phone1 = value;
                OnPropertyChanged();
            }
        }

        public string phone2
        {
            get { return _phone2; }
            set
            {
                if (Equals(value, _phone2)) return;
                _phone2 = value;
                OnPropertyChanged();
            }
        }

        public string fax
        {
            get { return _fax; }
            set
            {
                if (value == _fax) return;
                _fax = value;
                OnPropertyChanged();
            }
        }

        public bool contactIdSpecified
        {
            get { return contactId > 0; }
        }

        public Dictionary<string, object> ToDto()
        {
            var dict = new Dictionary<string, object>
            {
                {"contactId", new DtoValue(contactId)},
                {"name", new DtoValue(name)},
                {"web", new DtoValue(web)},
                {"phone1", new DtoValue(phone1)},
                {"phone2", new DtoValue(phone2)},
                {"fax", new DtoValue(fax)},
                {"attention", new DtoValue(attention)},
                {"email", new DtoValue(email)}
            };
            return dict;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}