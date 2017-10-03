namespace CustomerAssignment.Customers.Request {

    export class UpdateCustomerAddressRequest {
        public customerId: string;
        public country: string;
        public city: string;
        public street: string;
        public houseNumber: string;
        public appartmentNumber: string;
        public zipCode: string;
    }
}