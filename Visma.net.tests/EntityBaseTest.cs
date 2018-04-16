using System;
using System.IO;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using Xunit;

namespace Visma.net.tests
{
    public abstract class EntityBaseTest<T> where T : DtoProviderBase
    {
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
            var patch = VismaNetTestHelpers.CreateDtoDiff<T>(_dto, _update);
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
            var log = $"{patch}" + Environment.NewLine + Environment.NewLine + $"{token1}" + Environment.NewLine +
                      Environment.NewLine + $"{token2}";
            File.WriteAllText(@"C:\temp\vismanetdiffpatch-" + typeof(T).Name + "-all-props.json", log);
            Assert.Null(patch);
        }
    }
}