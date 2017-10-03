namespace CustomerAssignment.Customers {

    class CustomerInfoController {

        customerInfo: Models.CustomerContactCard;

        static $inject = ['$state', '$stateParams', '$log', 'customersService'];
        constructor(private $state: angular.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $log: ng.ILogService,
            private customersService: ICustomersService) {
            var vm = this;

            var customerId = $stateParams['id'];
            if (!angular.isUndefined(customerId)) {
                vm.loadData(customerId);
            } else {
                $log.error("No id passed in param! (CustomerInfoController)");
            }
            
        }

        public editCustomer() {
            var vm = this;

            vm.$state.go('customers.edit', { id: vm.customerInfo.customerId });
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
        .controller('CustomerInfoController', CustomerInfoController);


}