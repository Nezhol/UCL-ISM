using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;

namespace UCL_InternationalStudentManagement.Models
{
    public class UserModel
    {
        private AuthenticationProviderType _type;
        private AuthenticationCredentials _credentials;
        private AuthenticationCredentials _token;
        private Guid _userId;

        public UserModel(AuthenticationProviderType type, string userName, string password, string domain)
        {
            if (type != AuthenticationProviderType.ActiveDirectory)
            {
                _credentials = new AuthenticationCredentials();
                _credentials.ClientCredentials.UserName.UserName = userName;
                _credentials.ClientCredentials.UserName.Password = password;
                _credentials.SupportingCredentials = new AuthenticationCredentials();
                //_credentials.SupportingCredentials.ClientCredentials = Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
            }
            else
            {
                _credentials = new AuthenticationCredentials();
                _credentials.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(userName, password, domain);
            }
        }
    }
}
