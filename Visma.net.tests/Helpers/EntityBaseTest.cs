using System;
using System.IO;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using Xunit;
using Xunit.Abstractions;

namespace Visma.net.tests
{
    public abstract class EntityBaseTest<T> where T : DtoProviderBase
    {
        protected ITestOutputHelper output;

        protected EntityBaseTest(string dto, string update)
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
        public void CanDeserializeToT()
        {
            var inventory = JsonConvert.DeserializeObject<T>(PrepareDtoForSerializer(_dto), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            });
            Assert.IsType<T>(inventory);
        }

        [Fact]
        public void CanSerializeToUpdateDto()
        {
            if (_update == null) return;
            var patch = VismaNetTestHelpers.CreateDtoDiff<T>(PrepareDtoForUpdate(_dto), PrepareUpdateDto(_update));
            if(patch != null)
                output?.WriteLine(patch.ToString(Formatting.Indented));
            Assert.Null(patch);
        }

        [Fact]
        public void ContainsAllProperties()
        {
            var settings = VismaNetTestHelpers.SerializerSettings;
            settings.NullValueHandling = NullValueHandling.Include;
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            var entity = JsonConvert.DeserializeObject<T>(PrepareDtoForSerializer(_dto), settings);
            var src = JsonConvert.SerializeObject(entity, VismaNetTestHelpers.SerializerSettings);
            var token1 = JToken.Parse(src.ToLower());
            var token2 = JToken.Parse(PrepareDtoForSerializer(_dto).ToLower());
            var jdp = new JsonDiffPatch();
            var patch = jdp.Diff(token1, token2);
            if(patch != null)
                output?.WriteLine(patch.ToString(Formatting.Indented));
            Assert.Null(patch);
        }
    }
}