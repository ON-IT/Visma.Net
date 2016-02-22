namespace ONIT.VismaNetApi.Models
{
    public class NotDto<T> : IProvideCustomDto
    {
        private readonly T _data;

        public NotDto(T i)
        {
            _data = i;
        }

        public T Value
        {
            get { return _data; }
        }

        public object ToDto()
        {
            return _data;
        }

        public static implicit operator NotDto<T>(T data)
        {
            return new NotDto<T>(data);
        }

        public static NotDto<T> From(T val)
        {
            return new NotDto<T>(val);
        }
    }
}