namespace CustomerAssignment.Customers {

    class CustomersListController {

        customerListEntries: any[];

        static $inject = ['customersService'];
        constructor(private customersService: ICustomersService) {
            var vm = this;

            vm.loadData();
        }

        private loadData() {
            var vm = this;

            vm.customersService.getCustomerListEntires().then((data) => {
                vm.customerListEntries = data;
            });
        }
    }

    angular
        .module('customerAssignment.customers')
        .controller('CustomersListController', CustomersListController);
}