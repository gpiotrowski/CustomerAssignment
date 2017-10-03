namespace CustomerAssignment.Customers.Request {

    export class UpdateCustomerContactRequest {
        public customerId: string;
        public countryCode: number;
        public phoneNumber: string;
    }
}