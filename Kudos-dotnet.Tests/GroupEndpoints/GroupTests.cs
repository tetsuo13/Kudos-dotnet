using Kudos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Kudos.Tests.GroupEndpoints
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public async Task GetAllGroups()
        {
            string json = Helpers.ReadExternalJsonFile("GroupEndpoints", "Groups.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            Groups groups = await kudos.GetGroupsAsync();

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public async Task GetGroup18104()
        {
            string json = Helpers.ReadExternalJsonFile("GroupEndpoints", "GetGroup18104.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            Group group = await kudos.GetGroupAsync(18104);

            Assert.IsNotNull(group);
        }
    }
}
