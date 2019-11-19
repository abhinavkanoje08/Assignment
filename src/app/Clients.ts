export class IClients {
    Cid: number;
    Dob: Date;
    FirstName: string;
    LastName: string;
    clientAdd: IAddress[];

}

export class IAddress {
    Cid: number;
    ClientAddressId: number;
    Address: string;

}