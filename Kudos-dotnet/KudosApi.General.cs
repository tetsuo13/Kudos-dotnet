using Kudos.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Kudos
{
    public partial class KudosApi : IKudosApi
    {
        /// <summary>
        /// The Service Provider Configuration endpoint is where a client can
        /// retrieve detailed information on the Kudos SCIM implimentation.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<ServiceProviderConfig> GetServiceProviderConfigsAsync(CancellationToken cancel = default(CancellationToken))
        {
            const string path = "ServiceProviderConfigs";
            return await Get<ServiceProviderConfig>(path, cancel);
        }
    }
}
