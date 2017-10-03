namespace CustomerAssignment.Customers {

    export interface ICustomersService {
        getCustomerListEntires(): angular.IPromise<any>;
    }

    class CustomersService implements ICustomersService {

        static $inject = ['$http', '$log', 'customersEndpoint'];
        constructor(private $http: ng.IHttpService, private $log: ng.ILogService, private customersEndpoint: string) {

        }

        getCustomerListEntires(): angular.IPromise<any> {
            var vm = this;

            return vm.$http.get(`${vm.customersEndpoint}api/Customers/GetCustomerList`).then(
                (response) => response.data,
                (error) => {
                    vm.$log.error(error);
                });
        }

    }

    angular
        .module('customerAssignment.customers')
        .service('customersService', CustomersService);

}