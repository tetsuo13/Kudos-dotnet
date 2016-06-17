using Kudos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Kudos.Tests.GroupEndpoints
{
    [TestClass]
    public class GroupSchemaTests
    {
        [TestMethod]
        public async Task TestGroupSchemaEndpoint()
        {
            string json = Helpers.ReadExternalJsonFile("GroupEndpoints", "GroupSchema.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            GroupSchema schema = await kudos.GetGroupSchemaAsync();

            Assert.IsNotNull(schema);
        }
    }
}
