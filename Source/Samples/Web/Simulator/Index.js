Bifrost.namespace("Web.Simulator", {
    Index: Bifrost.views.ViewModel.extend(function (simulatorHub) {
        var self = this;

        this.tenants = ko.observableArray();

        simulatorHub.server.getAllTenants().continueWith(this.tenants);

        this.currentTenant = ko.observable(null);
    })
});
