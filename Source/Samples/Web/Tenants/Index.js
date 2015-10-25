Bifrost.namespace("Web.Tenants", {
    Index: Bifrost.views.ViewModel.extend(function (authenticationHub, tenantsHub) {
        var self = this;

        this.tenants = ko.observableArray();

        tenantsHub.server.getAll().continueWith(this.tenants);

        tenantsHub.client(function (client) {
            client.tenantSaved = function (savedTenant) {

                var hasTenant = self.tenants.some(function (tenant) {
                    if (tenant.tenant == savedTenant.tenant) return true;
                    return false;
                })

                if (!hasTenant) self.tenants.push(savedTenant);
            }
        });

        this.isNew = ko.observable(false);
        this.currentTenant = ko.observable(null);

        this.createNew = function () {
            self.isNew(true);
            self.currentTenant({
                tenant: "[Not Set]",
                clientId: "[Not Set]",
                clientSecret: "[Not Set]"
            });
            
        };

        this.save = function () {
            tenantsHub.server.save(self.currentTenant()).continueWith(function () {
                self.isNew(false);
            });
        };

        this.authenticate = function () {
            authenticationHub.server.authenticate(self.currentTenant().tenant, self.currentTenant().client).continueWith(function (url) {
                document.location = url;
            });
        }
    })
});
