namespace CustomerAssignment.Customers {

    class CustomerCreateController {

        newCustomer: Request.CreateNewCustomerRequest;

        static $inject = ['$state', 'customersService'];
        constructor(private $state: angular.ui.IStateService, private customersService: ICustomersService) {
            var vm = this;
        }

        public createNewCustomer() {
            var vm = this;

            vm.customersService.createCustomer(vm.newCustomer).then((customerId: string) => {
                vm.$state.go('customers.info', { id: customerId});
            });
        }

    }

    angular
        .module('customerAssignment.customers')
        .controller('CustomerCreateController', CustomerCreateController);
}