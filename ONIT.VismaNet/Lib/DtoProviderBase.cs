using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
    public class DtoProviderBase : IProvideDto, INotifyPropertyChanged
    {
		HashSet<string> _ignoreProperties;
		protected HashSet<string> IgnoreProperties => _ignoreProperties ?? (_ignoreProperties = new HashSet<string>());

        protected T Get<T>([CallerMemberName] string key = null, T defaultValue = default(T))
        {
            object value;
            if (!_data.TryGetValue(key, out value))
            {
                _data[key] = defaultValue;
                return defaultValue;
            }

            if (value is long)
            {
                return (T) (object) Convert.ToInt32((long) value);
            }
            if (EqualityComparer<T>.Default.Equals((T) value, default(T)))
            {
                _data[key] = defaultValue;
                return defaultValue;
            }

            return (T) value;
        }

        protected void Set(object dto, [CallerMemberName] string key = null, bool silent = false)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (dto == null && _data.ContainsKey(key))
            {
                _data.Remove(key);
                if(!silent) OnPropertyChanged(key);
            }
            else
            {
                if (!_data.ContainsKey(key) || _data[key] != dto)
                {
                    _data[key] = dto;
                    if (!silent) OnPropertyChanged(key);
                }
            }
        }

        public void UpdateValuesFrom<T>(T source) where T : DtoProviderBase
        {
            foreach (var entry in source.Data)
            {

               Set(entry.Value, entry.Key);
            }
        }

        private Dictionary<string, object> _data;
        private Dictionary<string, object> _dtoFields;


        protected Dictionary<string, object> Data => _data ?? (_data = new Dictionary<string, object>());

        public object this[string index]
        {
            get
            {
                object value;
                return _data.TryGetValue(index, out value) ? value : null;
            }
            set
            {
                if (_data[index] != value)
                {
                    _data[index] = value;
                    OnPropertyChanged(index);
                }
            }
        }

        private static object CreateDto(object value, string key)
        {
            try
            {
                var providesDto = value as IProvideDto;
                if (providesDto != null)
                {
                    return new DtoValue(providesDto.ToDto());
                }
                var becomesDto = value as IBecomeDto;
                if (becomesDto != null)
                {
                    return becomesDto.ToDto();
                }
                var providesCustomDto = value as IProvideCustomDto;
                if (providesCustomDto != null)
                {
                    return providesCustomDto.ToDto();
                }
                var listOfProvidesDto = value as IEnumerable<IProvideDto>;
                if (listOfProvidesDto != null)
                {
                    return listOfProvidesDto.Select(x => x.ToDto()).ToList();
                }
                if (string.IsNullOrEmpty(string.Format("{0}", value)))
                    return null;
                return new DtoValue(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected Dictionary<string, object> DtoFields => _dtoFields ?? (_dtoFields = new Dictionary<string, object>());

        public virtual Dictionary<string, object> ToDto()
        {
			var dict = _data.Where(x => (_ignoreProperties==null || !_ignoreProperties.Contains(x.Key)))
                            .ToDictionary(x => CreateKey(x.Key), 
                                          x => CreateDto(x.Value, x.Key));

            foreach (var dtoField in DtoFields.Where(dtoField => !dict.ContainsKey(dtoField.Key)))
            {
                if(dtoField.Value == null)
                    continue;
                if (dtoField.Value is DtoValue)
                    dict[dtoField.Key] = dtoField.Value;
                else
                    dict[dtoField.Key] = CreateDto(dtoField.Value, dtoField.Key);
            }
            return dict;
        }

        private static string CreateKey(string key)
        {
            return key ?? string.Format("UNKNOWN{0}", Guid.NewGuid());
        }

        protected DtoProviderBase()
        {
            _data = new Dictionary<string, object>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal virtual void PrepareForUpdate()
        {
            
        }
    }
}