namespace CustomerAssignment.Customers {

    class CustomerEditController {

        currentTab = 0;
        customerInfo: Models.CustomerContactCard;

        static $inject = ['$state', '$stateParams', '$log', 'customersService'];
        constructor(private $state: angular.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $log: ng.ILogService,
            private customersService: ICustomersService) {
            var vm = this;

            var customerId = $stateParams['id'];
            if (!angular.isUndefined(customerId)) {
                vm.loadData(customerId);
            } else {
                $log.error("No id passed in param! (CustomerEditController)");
            }
        }

        public updateCustomerName() {
            var vm = this;

            var updateCustomerNameRequest = new Request.UpdateCustomerNameRequest();
            updateCustomerNameRequest.customerId = vm.customerInfo.customerId;
            updateCustomerNameRequest.firstName = vm.customerInfo.name.firstName;
            updateCustomerNameRequest.lastName = vm.customerInfo.name.lastName;

            vm.customersService.updateCustomerName(updateCustomerNameRequest).then(() => {
                vm.$state.go('customers.info', { id: vm.customerInfo.customerId });
            });
        }

        public updateCustomerAddress() {
            var vm = this;

            var updateCustomerAddressRequest = new Request.UpdateCustomerAddressRequest();
            updateCustomerAddressRequest.customerId = vm.customerInfo.customerId;
            updateCustomerAddressRequest.appartmentNumber = vm.customerInfo.address.appartmentNumber;
            updateCustomerAddressRequest.city = vm.customerInfo.address.city;
            updateCustomerAddressRequest.country = vm.customerInfo.address.country;
            updateCustomerAddressRequest.houseNumber = vm.customerInfo.address.houseNumber;
            updateCustomerAddressRequest.street = vm.customerInfo.address.street;
            updateCustomerAddressRequest.zipCode = vm.customerInfo.address.zipCode;

            vm.customersService.updateCustomerAddress(updateCustomerAddressRequest).then(() => {
                vm.$state.go('customers.info', { id: vm.customerInfo.customerId });
            });
        }

        private loadData(customerId: string) {
            var vm = this;

            vm.customersService.getCustomerInfo(customerId).then((data) => {
                vm.customerInfo = data;
            });
        }

    }

    angular
        .module('customerAssignment.customers')
        .controller('CustomerEditController', CustomerEditController);

}