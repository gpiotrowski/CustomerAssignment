namespace CustomerAssignment {

    class Routing {

        static $inject = ["$urlRouterProvider"];
        constructor($urlRouterProvider: ng.ui.IUrlRouterProvider) {
            $urlRouterProvider.otherwise('customers/list');
        }
    }

    angular
        .module('customerAssignment')
        .config(Routing);
}