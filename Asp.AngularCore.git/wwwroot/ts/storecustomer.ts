class CustomerStore {

    constructor(private firstName: string, private lastName: string) {

    }

    public visit: number = 0;
    private ourName: string;
    public showName() {
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
