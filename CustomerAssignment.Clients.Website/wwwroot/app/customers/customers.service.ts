namespace CustomerAssignment.Customers {

    export interface ICustomersService {
        getCustomerListEntires(): angular.IPromise<Models.CustomerListEntry[] | void>;
        createCustomer(newCustomer: Request.CreateNewCustomerRequest): angular.IPromise<string | void>;
        getCustomerInfo(customerId: string): angular.IPromise<any>;
        updateCustomerName(request: Request.UpdateCustomerNameRequest): angular.IPromise<void>;
        updateCustomerAddress(updateCustomerAddressRequest: Request.UpdateCustomerAddressRequest): angular.IPromise<void>;
        updateCustomerContact(updateCustomerContactRequest: Request.UpdateCustomerContactRequest): angular.IPromise<void>;
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

        createCustomer(newCustomer: Request.CreateNewCustomerRequest): angular.IPromise<string | void> {
            var vm = this;

            return vm.$http.post(`${vm.customersEndpoint}api/Customers/CreateCustomer`, newCustomer).then(
                (response) => response.data as string,
                (error) => {
                    vm.$log.error(error);
                });
        }

        getCustomerInfo(customerId: string): angular.IPromise<Models.CustomerContactCard | void> {
            var vm = this;

            return vm.$http.get(`${vm.customersEndpoint}api/Customers/GetCustomerContactCard?customerId=${customerId}`).then(
                (response) => response.data as Models.CustomerContactCard,
                (error) => {
                    vm.$log.error(error);
                });
        }

        updateCustomerName(updateCustomerNameRequest: Request.UpdateCustomerNameRequest): angular.IPromise<void> {
            var vm = this;

            return vm.$http.post(`${vm.customersEndpoint}api/Customers/UpdateCustomerName`, updateCustomerNameRequest).then(
                (response) => { },
                (error) => {
                    vm.$log.error(error);
                });
        }

        updateCustomerAddress(updateCustomerAddressRequest: Request.UpdateCustomerAddressRequest): angular.IPromise<void> {
            var vm = this;

            return vm.$http.post(`${vm.customersEndpoint}api/Customers/UpdateCustomerAddress`, updateCustomerAddressRequest).then(
                (response) => { },
                (error) => {
                    vm.$log.error(error);
                });
        }

        updateCustomerContact(updateCustomerContactRequest: Request.UpdateCustomerContactRequest): angular.IPromise<void> {
            var vm = this;

            return vm.$http.post(`${vm.customersEndpoint}api/Customers/UpdateCustomerContactInfo`, updateCustomerContactRequest).then(
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