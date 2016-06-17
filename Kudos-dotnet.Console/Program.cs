using Kudos;
using Kudos.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        private const string AuthorizationToken = "";

        public static void Main()
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            IKudosApi kudos;
            kudos = new KudosApi(AuthorizationToken);

            // Use the following to monitor through Fiddler.
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                CookieContainer = new CookieContainer(),
                Proxy = new WebProxy("http://localhost:8888", false),
                UseProxy = true,
                UseDefaultCredentials = false
            };
            //kudos = new KudosApi(AuthorizationToken, new HttpClient(clientHandler));

            ServiceProviderConfig config = await kudos.GetServiceProviderConfigsAsync();
            Console.WriteLine(config.DocumentationUrl);

            await UserEndpoint(kudos);
            await GroupEndpoint(kudos);
        }

        private static async Task GroupEndpoint(IKudosApi kudos)
        {
            GroupSchema schema = await kudos.GetGroupSchemaAsync();

            Groups groups = await kudos.GetGroupsAsync();
            foreach (Group group in groups.Resources)
            {
                Console.WriteLine(group.DisplayName);
            }
        }

        private static async Task UserEndpoint(IKudosApi kudos)
        {
            UserSchema schema = await kudos.GetUserSchemaAsync();
            Console.WriteLine(schema.Description);

            Users users = await kudos.GetUsersAsync();
            foreach (User u in users.Resources)
            {
                Console.WriteLine("{0} {1} {2}", u.Name.GivenName, u.Name.FamilyName, u.Id);
            }

            User user = await kudos.GetUserAsync(42);
            Console.WriteLine("{0} {1} in {2}, Born {3}",
                user.Name.GivenName, user.Name.FamilyName, user.Enterprise.Department,
                user.Kudos.DateOfBirth.ToShortDateString());

            UpdateUser update = new UpdateUser()
            {
                Kudos = new Kudos.Models.Extensions.UpdateKudosExtension()
                {
                    DateOfBirth = new DateTime(1953, 1, 20)
                }
            };
            User result = await kudos.UpdateUserAsync(42, update);
            Console.WriteLine("{0} {1} in {2}, born {3}",
                result.Name.GivenName, result.Name.FamilyName, result.Enterprise.Department,
                result.Kudos.DateOfBirth.ToShortDateString());

            User newUser = new User()
            {
                UserName = "foo@bar.com"
            };
            User response = await kudos.CreateUserAsync(newUser);
            Console.WriteLine("User ID {0} created for {1}", response.Id, response.UserName);

            await kudos.DeleteUserAsync(42);
        }
    }
}
