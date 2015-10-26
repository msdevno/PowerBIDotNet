using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bifrost.Extensions;
using Events;
using PowerBIDotNet;

namespace Desktop.Tenants
{
    public class ViewModel
    {
        ObservableCollection<TenantConfiguration> _tenantsCollection = new ObservableCollection<TenantConfiguration>();
        IConfigurationForTenants _configurationForTenants;
        IAuthentication _authentication;
        IWorkspaces _workspaces;

        public ViewModel(IConfigurationForTenants configurationForTenants, IAuthentication authentication, IWorkspaces workspaces)
        {
            _configurationForTenants = configurationForTenants;
            
            _workspaces = workspaces;

            _authentication = authentication;

            configurationForTenants.GetAll().ForEach(_tenantsCollection.Add);
        }

        public IEnumerable<TenantConfiguration> Tenants { get { return _tenantsCollection; } }

        public virtual TenantConfiguration SelectedTenant { get; set; }

        public void AddTenant(string name)
        {
            var tenant = new TenantConfiguration { Tenant = name };
            _configurationForTenants.Save(tenant);
            _tenantsCollection.Add(tenant);
            SelectedTenant = tenant;
        }

        public void Authenticate()
        {
            var tokens = _authentication.GetTokens(SelectedTenant.Client);
            SelectedTenant.AccessToken = tokens.AccessToken;
            SelectedTenant.RefreshToken = tokens.RefreshToken;
            _configurationForTenants.Save(SelectedTenant);
        }

        public void RefreshToken()
        {
            var tokens = _authentication.RefreshToken(SelectedTenant.Client, SelectedTenant.RefreshToken);
            SelectedTenant.AccessToken = tokens.AccessToken;
            SelectedTenant.RefreshToken = tokens.RefreshToken;
            _configurationForTenants.Save(SelectedTenant);
        }


        public void CreateDataset()
        {
            if (string.IsNullOrEmpty(SelectedTenant.Dataset) ||
                string.IsNullOrEmpty(SelectedTenant.Table))
                return;

            var workspace = _workspaces.GetFor(SelectedTenant.Tenant);
            workspace.Datasets.Create(SelectedTenant.Dataset, workspace.Tables.GetTableSchemaFor<Message>(SelectedTenant.Table));
        }

        public void Save()
        {
            _configurationForTenants.Save(SelectedTenant);
        }
    }
}
