namespace CustomerAssignment.Customers {

    class CustomersListController {

        customerListEntries: Models.CustomerListEntry[];
        dtOptions: any;

        static $inject = ['$state', 'DTOptionsBuilder', 'customersService'];
        constructor(private $state: angular.ui.IStateService, private DTOptionsBuilder, private customersService: ICustomersService) {
            var vm = this;

            vm.configureDataTable();
            vm.loadData();
        }

        public selectCustomer(customerId: string) {
            var vm = this;

            vm.$state.go('customers.info', { id: customerId });
        }

        private loadData() {
            var vm = this;

            vm.customersService.getCustomerListEntires().then((data: Models.CustomerListEntry[]) => {
                vm.customerListEntries = data;
            });
        }

        private configureDataTable() {
            var vm = this;

            vm.dtOptions = vm.DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(10)
                .withDOM('trp');
        }
    }

    angular
        .module('customerAssignment.customers')
        .controller('CustomersListController', CustomersListController);
}