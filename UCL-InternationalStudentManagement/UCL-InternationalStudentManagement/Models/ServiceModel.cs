using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;

namespace UCL_InternationalStudentManagement.Models
{
    public class ServiceModel
    {
        /// <summary>
        /// Local variables
        /// </summary>
        private string _discoveryService;
        private string _orgUniqueName;

        private IServiceManagement<IDiscoveryService> _discoveryManagement;
        private DiscoveryServiceProxy _discoveryProxy;

        private string _orgUri;

        private AuthenticationProviderType _type;

        /// <summary>
        /// Public variables
        /// </summary>
        public string OrgUri
        {
            private set { _orgUri = value; }
            get { return _orgUri; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="discoveryService"></param>
        public ServiceModel(string discoveryService)
        {
            _discoveryManagement = ServiceConfigurationFactory.CreateManagement<IDiscoveryService>(new Uri(discoveryService));
            _type = _discoveryManagement.AuthenticationType;

            OrgUri = string.Empty;

            using (_discoveryProxy)
            {
                if (_discoveryProxy != null)
                {
                    OrganizationDetailCollection organizationDetails = DiscoverOrganizations(_discoveryProxy);
                    OrgUri = FindOrganization(_orgUniqueName, organizationDetails.ToArray()).Endpoints[EndpointType.OrganizationService];
                }
            }
        }

        /// <summary>
        /// Discovers the organizations that the calling user belongs to.
        /// </summary>
        /// <param name="service">A Discovery service proxy instance.</param>
        /// <returns>Array containing detailed information on each organization that 
        /// the user belongs to.</returns>
        public OrganizationDetailCollection DiscoverOrganizations(
            IDiscoveryService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            RetrieveOrganizationsRequest orgRequest = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse orgResponse =
                (RetrieveOrganizationsResponse)service.Execute(orgRequest);

            return orgResponse.Details;
        }

        /// <summary>
        /// Finds a specific organization detail in the array of organization details
        /// returned from the Discovery service.
        /// </summary>
        /// <param name="orgUniqueName">The unique name of the organization to find.</param>
        /// <param name="orgDetails">Array of organization detail object returned from the discovery service.</param>
        /// <returns>Organization details or null if the organization was not found.</returns>
        /// <seealso cref="DiscoveryOrganizations"/>
        public OrganizationDetail FindOrganization(string orgUniqueName,
            OrganizationDetail[] orgDetails)
        {
            if (String.IsNullOrWhiteSpace(orgUniqueName))
                throw new ArgumentNullException("orgUniqueName");
            if (orgDetails == null)
                throw new ArgumentNullException("orgDetails");
            OrganizationDetail orgDetail = null;

            foreach (OrganizationDetail detail in orgDetails)
            {
                if (String.Compare(detail.UniqueName, orgUniqueName,
                    StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    orgDetail = detail;
                    break;
                }
            }
            return orgDetail;
        }
    }
}
