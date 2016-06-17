using Kudos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Kudos.Tests.GeneralEndpoints
{
    [TestClass]
    public class ServiceProviderConfigTests
    {
        [TestMethod]
        public async Task TestServiceProviderConfigEndpoint()
        {
            string json = Helpers.ReadExternalJsonFile("GeneralEndpoints", "ServiceProviderConfig.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            ServiceProviderConfig config = await kudos.GetServiceProviderConfigsAsync();

            Assert.IsNotNull(config);
        }
    }
}
