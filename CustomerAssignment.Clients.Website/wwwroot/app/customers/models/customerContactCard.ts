namespace CustomerAssignment.Customers.Models {

    export class CustomerContactCard {
        public customerId: string;
        public name: CustomerName;
        public address: CustomerAddress;
        public contactPhone: CustomerContactPhone;
    }

    export class CustomerName {
        public firstName: string;
        public lastName: string;
    }

    export class CustomerAddress {
        public country: string;
        public city: string;
        public street: string;
        public houseNumber: string;
        public appartmentNumber: string;
        public zipCode: string;
    }

    export class CustomerContactPhone {
        public countryCode: number;
        public phoneNumber: string;
    }

}