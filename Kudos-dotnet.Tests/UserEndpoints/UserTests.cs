using Kudos.Models;
using Kudos.Models.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Kudos.Tests.UserEndpoints
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public async Task GetAllUsers()
        {
            string json = Helpers.ReadExternalJsonFile("UserEndpoints", "Users.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            Users users = await kudos.GetUsersAsync();

            Assert.IsNotNull(users);
        }

        [TestMethod]
        public async Task GetUser53792()
        {
            string json = Helpers.ReadExternalJsonFile("UserEndpoints", "GetUser53792.json");

            IKudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(json));
            User user = await kudos.GetUserAsync(52792);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task UpdateUserNameAndName_Generates_StrictJson()
        {
            UpdateUser user = new UpdateUser()
            {
                UserName = "user@example.com",
                Name = new UserName()
                {
                    GivenName = "Smith",
                    FamilyName = "Barbara"
                }
            };

            string expected = String.Format(@"{{""schemas"":[""urn:scim:schemas:core:1.0""],""userName"":""{0}"",""name"":{{""givenName"":""{1}"",""familyName"":""{2}""}}}}",
                user.UserName, user.Name.GivenName, user.Name.FamilyName);

            KudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(String.Empty));
            await kudos.UpdateUserAsync(53792, user);

            Assert.AreEqual(expected, kudos.LastStringContent);
        }

        [TestMethod]
        public async Task UpdateBirthday_Generates_StrictJson()
        {
            UpdateUser user = new UpdateUser()
            {
                Kudos = new UpdateKudosExtension()
                {
                    DateOfBirth = new DateTime(2016, 1, 2)
                }
            };

            const string expected = @"{""schemas"":[""urn:scim:schemas:core:1.0"",""urn:scim:schemas:extension:kudos:1.0""],""urn:scim:schemas:extension:kudos:1.0"":{""dateOfBirth"":""2016-01-02T00:00:00""}}";

            KudosApi kudos = new KudosApi(null, Helpers.PrepareHttpClient(String.Empty));
            await kudos.UpdateUserAsync(53792, user);

            Assert.AreEqual(expected, kudos.LastStringContent);
        }
    }
}
