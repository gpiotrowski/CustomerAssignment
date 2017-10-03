namespace CustomerAssignment.Customers {

    export interface ICustomersService {
        getCustomerListEntires(): angular.IPromise<Models.CustomerListEntry[] | void>;
        createCustomer(newCustomer: Request.CreateNewCustomerRequest): angular.IPromise<void>;
    }

    class CustomersService implements ICustomersService {

        static $inject = ['$http', '$log', 'customersEndpoint'];
        constructor(private $http: ng.IHttpService, private $log: ng.ILogService, private customersEndpoint: string) {

        }

        getCustomerListEntires(): angular.IPromise<Models.CustomerListEntry[] | void> {
            var vm = this;

            return vm.$http.get(`${vm.customersEndpoint}api/Customers/GetCustomerList`).then(
                (response) => response.data as Models.CustomerListEntry[],
                (error) => {
                    vm.$log.error(error);
                });
        }

        createCustomer(newCustomer: Request.CreateNewCustomerRequest): angular.IPromise<void> {
            var vm = this;

            return vm.$http.post(`${vm.customersEndpoint}api/Customers/CreateCustomer`, newCustomer).then(
                (response) => { },
                (error) => {
                    vm.$log.error(error);
                });
        }

    }

    angular
        .module('customerAssignment.customers')
        .service('customersService', CustomersService);

}