using Kudos.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kudos
{
    public partial class KudosApi : IKudosApi
    {
        /// <summary>
        /// The Users resource endpoint returns a description of the resource.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<UserSchema> GetUserSchemaAsync(CancellationToken cancel = default(CancellationToken))
        {
            const string path = "Schemas/Users";
            return await Get<UserSchema>(path, cancel);
        }

        /// <summary>
        /// Returns a list of all users in the organization.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<Users> GetUsersAsync(CancellationToken cancel = default(CancellationToken))
        {
            const string path = "Users";
            return await Get<Users>(path, cancel);
        }

        /// <summary>
        /// Returns a single user resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(int id, CancellationToken cancel = default(CancellationToken))
        {
            string path = string.Format("Users/{0}", id);
            return await Get<User>(path, cancel);
        }

        /// <summary>
        /// Creates a new user to the system. It is required that a username
        /// attribute be defined.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<User> CreateUserAsync(User user, CancellationToken cancel = default(CancellationToken))
        {
            const string path = "Users";
            user.Schemas = SchemasUsed(user);

            string json = JsonConvert.SerializeObject(user, Formatting.None, UserSerializerSettings);
            StringContent content = new StringContent(json, Encoding.UTF8, MediaType);

            return await Post<User>(path, content, cancel);
        }

        private IEnumerable<string> SchemasUsed<T>(T user)
        {
            ICollection<string> schemas = new List<string>();
            schemas.Add(Schemas.Core);

            if ((user is User && ((User)(object)user).Kudos != null) ||
                (user is UpdateUser && ((UpdateUser)(object)user).Kudos != null))
            {
                schemas.Add(Schemas.Kudos);
            }

            if ((user is User && ((User)(object)user).Enterprise != null) ||
                (user is UpdateUser && ((UpdateUser)(object)user).Enterprise != null))
            {
                schemas.Add(Schemas.Enterprise);
            }

            return schemas;
        }

        /// <summary>
        /// Updates the already created user at the specified id. Will not
        /// overwrite attributes with defaults which are not set.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(int id, UpdateUser user,
            CancellationToken cancel = default(CancellationToken))
        {
            string path = string.Format("Users/{0}", id);
            user.Schemas = SchemasUsed(user);

            string json = JsonConvert.SerializeObject(user, Formatting.None, UserSerializerSettings);
            LastStringContent = json;
            StringContent content = new StringContent(json, Encoding.UTF8, MediaType);

            return await Update<User>(path, content, cancel);
        }

        /// <summary>
        /// Removes a user from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        public async Task DeleteUserAsync(int id, CancellationToken cancel = default(CancellationToken))
        {
            string path = string.Format("Users/{0}", id);
            await Delete<ErrorResponse>(path, cancel);
        }
    }
}
