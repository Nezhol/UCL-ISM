using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Discovery;

namespace UCL_InternationalStudentManagement.Models
{
    public class AuthenticationModel
    {
        private IServiceManagement<IOrganizationService> _orgManagement;
        private OrganizationServiceProxy _orgProxy;
        private AuthenticationCredentials _credentials;

        public OrganizationServiceProxy OrgProxy { get => _orgProxy; set => _orgProxy = value; }

        private Guid _userId;

        public AuthenticationModel(IServiceManagement<IDiscoveryService> discoveryManagement, string uri)
        {
            if (discoveryManagement.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
            {
                _orgManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(uri));
                AuthenticationCredentials token = _orgManagement.Authenticate(_credentials);
                OrgProxy = new OrganizationServiceProxy(_orgManagement, token.SecurityTokenResponse);
            }
            else
            {
                _orgManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(uri));
                OrgProxy = new OrganizationServiceProxy(_orgManagement, _credentials.ClientCredentials);
            }
        }
    }
}
