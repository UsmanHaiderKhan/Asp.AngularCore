class CustomerStore {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.visit = 0;
    }
    showName() {
        alert(this.firstName + " " + this.lastName);
    }
    set khan(val) {
        this.ourName = val;
    }
    get khan() {
        return this.ourName;
    }
}
//let customer = new CustomerStore();
//customer.visit = 123;
//# sourceMappingURL=storecustomer.js.map