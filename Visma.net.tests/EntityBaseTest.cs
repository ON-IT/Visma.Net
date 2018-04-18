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

        [Fact]
        public void CanDeserializeToT()
        {
            var inventory = JsonConvert.DeserializeObject<T>(_dto);
            Assert.IsType<T>(inventory);
        }

        [Fact]
        public void CanSerializeToUpdateDto()
        {
            if (_update == null) return;
            var patch = VismaNetTestHelpers.CreateDtoDiff<T>(_dto, _update);
            if(patch != null)
                output?.WriteLine(patch.ToString(Formatting.Indented));
            Assert.Null(patch);
        }

        [Fact]
        public void ContainsAllProperties()
        {
            var entity = JsonConvert.DeserializeObject<T>(_dto, VismaNetTestHelpers.SerializerSettings);
            var src = JsonConvert.SerializeObject(entity, VismaNetTestHelpers.SerializerSettings);
            var token1 = JToken.Parse(src.ToLower());
            var token2 = JToken.Parse(_dto.ToLower());
            var jdp = new JsonDiffPatch();
            var patch = jdp.Diff(token1, token2);
            if(patch != null)
                output?.WriteLine(patch.ToString(Formatting.Indented));
            Assert.Null(patch);
        }
    }
}