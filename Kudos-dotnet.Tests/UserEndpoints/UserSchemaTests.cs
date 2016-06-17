using Kudos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Kudos.Tests.UserEndpoints
{
    [TestClass]
    public class UserSchemaTests
    {
        [TestMethod]
        public async Task TestUserSchemaEndpoint()
        {
            string json = Helpers.ReadExternalJsonFile("UserEndpoints", "UserSchema.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            UserSchema schema = await kudos.GetUserSchemaAsync();

            Assert.IsNotNull(schema);
        }
    }
}
