using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public abstract class EntityBaseTest<T> : VerifyBase where T : DtoProviderBase
    {
        protected ITestOutputHelper output;

        protected EntityBaseTest(string dto, string update) : base()
        {
            _dto = dto;
            _update = update;
        }

        private readonly string _dto;
        private readonly string _update;

        /// <summary>
        /// Add, remove or manipulate properties that's not in the GET
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public virtual string PrepareDtoForUpdate(string src)
        {
            return src;
        }

        public virtual string PrepareDtoForSerializer(string src)
        {
            return src;
        }

        public virtual string PrepareUpdateDto(string src)
        {
            return src;
        }

        [Fact]
        public Task CanDeserializeToDto()
        {
            return Verify(CreateEntity().ToDto()).UseDirectory("../Snapshots");
        }

        [Fact]
        public Task CanDeserializeToEntity()
        {
            return Verify(CreateEntity()).UseDirectory("../Snapshots");
        }

        private T CreateEntity()
        {
            return JsonConvert.DeserializeObject<T>(PrepareDtoForSerializer(_dto), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            });
        }
    }
}