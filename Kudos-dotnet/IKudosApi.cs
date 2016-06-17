using Kudos.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Kudos
{
    public interface IKudosApi
    {
        string ApiToken { get; }

        #region General endpoints
        /// <summary>
        /// The Service Provider Configuration endpoint is where a client can
        /// retrieve detailed information on the Kudos SCIM implimentation.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<ServiceProviderConfig> GetServiceProviderConfigsAsync(CancellationToken cancel = default(CancellationToken));
        #endregion

        #region User endpoints
        /// <summary>
        /// The Users resource endpoint returns a description of the resource.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<UserSchema> GetUserSchemaAsync(CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Returns a list of all users in the organization.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<Users> GetUsersAsync(CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Returns a single user resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(int id, CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Creates a new user to the system. It is required that a username
        /// attribute be defined.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user, CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Updates the already created user at the specified id. Will not
        /// overwrite attributes with defaults which are not set.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<User> UpdateUserAsync(int id, UpdateUser user, CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Removes a user from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        Task DeleteUserAsync(int id, CancellationToken cancel = default(CancellationToken));
        #endregion

        #region Group endpoints
        /// <summary>
        /// Returns a description of groups.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<GroupSchema> GetGroupSchemaAsync(CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Returns a list of groups in the organization.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<Groups> GetGroupsAsync(CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Returns a single group resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task<Group> GetGroupAsync(int id, CancellationToken cancel = default(CancellationToken));

        /// <summary>
        /// Removes a group from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        Task DeleteGroupAsync(int id, CancellationToken cancel = default(CancellationToken));
        #endregion
    }
}
