namespace CustomerAssignment.Customers {

    class Routing {

        static $inject = ["$stateProvider"];
        constructor($stateProvider: angular.ui.IStateProvider) {

            var modulePath = "app/customers/";

            $stateProvider
                .state("customers",
                {
                    abstract: true,
                    url: "/customers",
                    template: "<div ui-view></div>"
                })
                .state("customers.list",
                {
                    url: "/list",
                    templateUrl: modulePath + "customers-list.html"
                });
        }
    }

    angular
        .module('customerAssignment.customers')
        .config(Routing);
}