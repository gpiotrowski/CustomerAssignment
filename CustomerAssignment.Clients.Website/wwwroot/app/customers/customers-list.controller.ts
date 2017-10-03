namespace CustomerAssignment.Customers {

    class CustomersListController {

        customerListEntries: Models.CustomerListEntry[];
        dtOptions: any;

        static $inject = ['DTOptionsBuilder', 'customersService'];
        constructor(private DTOptionsBuilder, private customersService: ICustomersService) {
            var vm = this;

            vm.configureDataTable();
            vm.loadData();
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