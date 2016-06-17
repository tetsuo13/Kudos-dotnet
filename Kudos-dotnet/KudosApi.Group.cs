using Kudos.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Kudos
{
    public partial class KudosApi : IKudosApi
    {
        /// <summary>
        /// Returns a description of groups.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<GroupSchema> GetGroupSchemaAsync(CancellationToken cancel = default(CancellationToken))
        {
            const string path = "Schemas/Groups";
            return await Get<GroupSchema>(path, cancel);
        }

        /// <summary>
        /// Returns a list of groups in the organization.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<Groups> GetGroupsAsync(CancellationToken cancel = default(CancellationToken))
        {
            const string path = "Groups";
            return await Get<Groups>(path, cancel);
        }

        /// <summary>
        /// Returns a single group resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<Group> GetGroupAsync(int id,
            CancellationToken cancel = default(CancellationToken))
        {
            string path = string.Format("Groups/{0}", id);
            return await Get<Group>(path, cancel);
        }

        /// <summary>
        /// Removes a group from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task DeleteGroupAsync(int id, CancellationToken cancel = default(CancellationToken))
        {
            string path = string.Format("Groups/{0}", id);
            await Delete<ErrorResponse>(path, cancel);
        }
    }
}
